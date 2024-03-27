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
    public T[] objects { get; set; }
}

public class ResponseBase<T> : ProtocolBase
{
    public T[] objects { get; set; }
    public int code { get; set; }
    public string message { get; set; }
}

// ---------------------------------------------------------------------
public class RqstGetMembers: RequestBase<IdInfo>
{
    public const string ACTION = "getMembers";
    public void RequestValidation()
    {
        if (this.name != ProtocolBase.SERVICE_NAME)
            throw new Exception("Wrong service name.");
        if (this.action != RqstGetMembers.ACTION)
            throw new Exception("Wrong action name.");
        if (this.objects?.Length > 0)
        {
            IdInfo info = this.objects[0];
            if (String.IsNullOrWhiteSpace(info.account))
                throw new Exception("Client account was not specified.");
            if (String.IsNullOrWhiteSpace(info.pwHash))
                throw new Exception("Client password was not specified.");
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