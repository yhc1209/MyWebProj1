namespace myWebProj1.Data;

/// <summary>
/// 成員資訊。
/// </summary>
public class TheMember
{
    public required int id { get; set; }
    public required string name { get; set; }
    public required int age { get; set; }
    public MemberGender gender { get; set; }
    public string remark { get; set; }
}

public enum MemberGender : int
{
    NotSure,
    Male,
    Female
}