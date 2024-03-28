namespace myWebProj1.Data;

/// <summary>
/// 身分的資訊。
/// </summary>
public class IdInfo
{
    public string machineName { get; set; }
    public string account { get; set; }
    public string pwHash { get; set; }

    public bool Validate(out string reason)
    {
        if (String.IsNullOrWhiteSpace(this.machineName))
        {
            reason = "Client machine name was not specified.";
            return false;
        }
        if (String.IsNullOrWhiteSpace(this.account))
        {
            reason = "Client account was not specified.";
            return false;
        }
        if (String.IsNullOrWhiteSpace(this.pwHash))
        {
            reason = "Client password was not specified.";
            return false;
        }

        // todo: validation
        reason = "";
        return true;
    }
}