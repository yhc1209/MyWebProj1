using myWebProj1.Data;
using Npgsql;

namespace myWebProj1.Utils;

public class PostgresCom : IDisposable
{
    private NpgsqlConnection _com;
    public PostgresCom(string ComString)
    {
        _com = new NpgsqlConnection(ComString);
        _com.Open();
    }
    public void Dispose()
    {
        _com?.Close();
        _com?.Dispose();
    }
}

/// <summary>
/// 管理<see cref="TheMember"/>資料庫的物件。
/// </summary>
[Obsolete("建議改用EF core版本。")]
public class TheMemberDB
{
    private static string comStr = "Host=localhost:5432;Username=postgres;Password=admin;Database=TheMemberServer";
    private const string TB_MEMBERS = "Members";

    private static string getNewMemberCmdTxt(TheMember member)
    {
        string cmdtxt = $"INSERT INTO \"{TB_MEMBERS}\" ";
        if (String.IsNullOrEmpty(member.remark))
        {
            cmdtxt += "(\"UserName\",\"Gender\",\"Age\") ";
            cmdtxt += $"VALUES ('{member.name}',{((int)member.gender)},{member.age})";
        }
        else
        {
            cmdtxt += "(\"UserName\",\"Gender\",\"Age\",\"Remark\") ";
            cmdtxt += $"VALUES ('{member.name}',{((int)member.gender)},{member.age},'{member.remark}')";
        }
        return cmdtxt;
    }

    public static async Task<TheMember[]> GetAllMembers()
    {
        List<TheMember> members = new List<TheMember>();
        await using (NpgsqlConnection com = new NpgsqlConnection(comStr))
        {
            await com.OpenAsync();
            await using (var cmd = new NpgsqlCommand($"SELECT * FROM \"{TB_MEMBERS}\"", com))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    int? identifier = reader["Identifier"] as int?;
                    string? username = reader["UserName"] as string;
                    int? userage = reader["Age"] as int?;
                    int? usergender = reader["Gender"] as int?;
                    string? remark = reader["Remark"] as string;
                    TheMember member = new TheMember(identifier.Value, username, userage.Value, usergender.Value, remark);
                    // Console.WriteLine(member.ToString());
                    members.Add(member);
                }
            }
            await com.CloseAsync();
        }
        return members.ToArray();
    }

    public static async Task<bool> NewMember(TheMember? member)
    {
        if (member == null)
            return false;
        string cmdTxt = getNewMemberCmdTxt(member);
        bool result = false;
        await using (NpgsqlConnection com = new NpgsqlConnection(comStr))
        {
            await com.OpenAsync();
            await using (var cmd = new NpgsqlCommand(cmdTxt, com))
            {
                int row = await cmd.ExecuteNonQueryAsync();
                result = (row == 1);
            }
            await com.CloseAsync();
        }
        return result;
    }
}