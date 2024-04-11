using System.Diagnostics.CodeAnalysis;

namespace myWebProj1.Data;

public class ProtocolBase
{
    public const string SERVICE_NAME = "TheMemberService";
    public required string name { get; init; }
    public required string action { get; init; }
}

public class RequestBase<T> : ProtocolBase
{
    public T[]? objects { get; set; }
}

public class ResponseBase<T> : ProtocolBase
{
    public T[]? objects { get; set; }
    public int code { get; set; }
    public string? message { get; set; }
}

// ---------------------------------------------------------------------
#region 取得所有成員資料
public class RqstGetMembers: RequestBase<IdInfo>
{
    public const string ACTION = "getMembers";
    public void RequestValidation()
    {
        if (this.name != ProtocolBase.SERVICE_NAME)
            throw new Exception("Wrong service name.");
        if (this.action != ACTION)
            throw new Exception("Wrong action name.");
        if (this.objects?.Length > 0)
        {
            if (!this.objects[0].Validate(out string reason))
                throw new Exception(reason);
        }
        else
            throw new Exception("IdInfo was not specified.");
    }
}

public class RespGetMembers: ResponseBase<TheMember>
{
    [SetsRequiredMembers]
    public RespGetMembers()
    {
        name = ProtocolBase.SERVICE_NAME;
        action = RqstGetMembers.ACTION;
    }
}
#endregion

#region 新增成員資料
public class RqstNewMember: RequestBase<MO_NewMember>
{
    public const string ACTION = "newMember";
    public void RequestValidation()
    {
        if (this.name != ProtocolBase.SERVICE_NAME)
            throw new Exception("Wrong service name.");
        if (this.action != ACTION)
            throw new Exception("Wrong action name.");
        if (this.objects?.Length > 0)
        {
            MO_NewMember data = this.objects[0];
            if (data.info == null)
                throw new NullReferenceException("The information of operator was not provided.");
            if (!data.info.Validate(out string reason))
                throw new Exception(reason);
            if (data.member == null)
                throw new Exception("The member info to new was not specified.");
        }
        else
            throw new Exception("IdInfo was not specified.");
    }
}

public class RespNewMember: ResponseBase<object>
{
    [SetsRequiredMembers]
    public RespNewMember()
    {
        name = ProtocolBase.SERVICE_NAME;
        action = RqstNewMember.ACTION;
    }
}
#endregion