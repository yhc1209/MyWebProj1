namespace myWebProj1.Utils;

public class Cmd
{
    /// <summary>是否更新database。</summary>
    public static bool DoUpdateDB { get; private set; } = false;

    /// <summary>嘗試進行command line的動作。</summary>
    /// <param name="args">main function的參數。</param>
    /// <returns>回傳是否進行了command line的動作。</returns>
    public static bool DoCmdAction(string[] args)
    {
        if (args?.Length > 0)
        {
            if (showVersion(args[0]))
                return true;
            UpdateDatabase(args[0]);
        }

        return false;;
    }
    private static bool showVersion(string cmd)
    {
        string[] acceptable_cmd = { "-v", "--version", "--Version" };

        if (!acceptable_cmd.Contains(cmd))
            return false;

        Console.WriteLine("--- My web project 1 ---");
        Console.WriteLine("  version: 1.0.0.0");
        Console.WriteLine("   author: YHC");
        return true;
    }
    public static bool UpdateDatabase(string cmd)
    {
        string[] acceptable_cmd = { "--updatedatabase", "--UpdateDatabase", "--UpdateDataBase" };

        if (acceptable_cmd.Contains(cmd))
            DoUpdateDB = true;

        return false;
    }
}