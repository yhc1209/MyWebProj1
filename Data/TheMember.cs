using System.Diagnostics.CodeAnalysis;
namespace myWebProj1.Data;

/// <summary>
/// 成員資訊。
/// </summary>
public class TheMember
{
    public int id { get; set; } = -1;
    public string name { get; set; } = "";
    public int age { get; set; } = 0;
    public MemberGender gender { get; set; } = MemberGender.NotSure;
    public string remark { get; set; } = "";

    public TheMember() {}

    [SetsRequiredMembers]
    public TheMember(int identifier, string username, int userage, int usergender, string remark = "")
    {
        this.id = identifier;
        this.name = username;
        this.age = userage;
        if (usergender == 1)
            this.gender = MemberGender.Male;
        else if (usergender == 2)
            this.gender = MemberGender.Female;
        else
            this.gender = MemberGender.NotSure;
        this.remark = remark;
    }
    public override string ToString()
    {
        switch (gender)
        {
            case MemberGender.Male:
                return $"Member#{id} {name}, is a {age}-year-old male.";
            case MemberGender.Female:
                return $"Member#{id} {name}, is a {age}-year-old female.";
            default:
                return $"{name} is a {age}-year-old member with ID #{id}.";
        }
    }
}

public enum MemberGender : int
{
    NotSure,
    Male,
    Female
}