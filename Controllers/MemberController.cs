using Microsoft.AspNetCore.Mvc;
using myWebProj1.Data;

namespace myWebProj1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    public static TheMember[] SAMPLE_DATA = new TheMember[] {
        new TheMember { id = 0, name = "Sasuke", age = 15, gender = MemberGender.Male, remark = "ninja" },
        new TheMember { id = 1, name = "Naruto", age = 16, gender = MemberGender.Male, remark = "ninja" },
        new TheMember { id = 2, name = "Doraemon", age = 60, gender = MemberGender.NotSure, remark = "cat robot" },
    };

    private readonly ILogger<MemberController> _logger;

    public MemberController(ILogger<MemberController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sample")]
    public IEnumerable<TheMember> GetSampleData()
    {
        return SAMPLE_DATA;
    }

    [HttpPost("getMembers")]
    public RespGetMembers GetMembersData(RqstGetMembers request)
    {
        RespGetMembers response = new RespGetMembers();
        try
        {
            request.RequestValidation();
            response.code = 0;
            response.message = "Successfull.";
            response.objects = SAMPLE_DATA;
            return response;
        }
        catch (Exception excp)
        {
            _logger.LogWarning(excp, "取database資料時候出例外。");
            response.code = -1;
            response.message = $"{excp.GetType()} - {excp.Message}";
            response.objects = Array.Empty<TheMember>();
            return response;
        }
    }
}