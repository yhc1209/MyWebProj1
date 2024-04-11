namespace myWebProj1.Data;

public class MO_NewMember
{
    public IdInfo? info { get; set; } = null;
    public TheMember? member { get; set; } = null;

    public MO_NewMember() {}

    public MO_NewMember(IdInfo info, TheMember member)
    {
        this.info = info;
        this.member = member;
    }
}