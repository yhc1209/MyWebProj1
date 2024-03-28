using Microsoft.AspNetCore.Mvc;
using myWebProj1.Data;
using myWebProj1.Utils;

namespace myWebProj1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    public static TheMember[] SAMPLE_DATA = new TheMember[] {
        new TheMember(0, "Sasuke", 15, 1, "ninja"),
        new TheMember(1, "Naruto", 16, 1, "ninja"),
        new TheMember(2, "Doraemon", 666, 0, "cat robot"),
    };

    private readonly ILogger<MemberController> _logger;

    public MemberController(ILogger<MemberController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sample")]
    public IEnumerable<TheMember> GetSampleData()
    {
        _logger.LogInformation($"[GetSampleData] ----------------------");
        return SAMPLE_DATA;
    }

    [HttpPost("getMembers")]
    public async Task<RespGetMembers> GetMembersData(RqstGetMembers request)
    {
        RespGetMembers response = new RespGetMembers();
        try
        {
            request.RequestValidation();
            _logger.LogInformation($"[GetMembersData] passed request validation.");
            response.code = 0;
            response.message = "Successfull.";
            response.objects = await TheMemberDB.GetAllMembers();
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

    [HttpPost("newMember")]
    public async Task<RespNewMember> NewMemberData(RqstNewMember request)
    {
        RespNewMember response = new RespNewMember();
        response.objects = Array.Empty<object>();
        try
        {
            _logger.LogInformation($"[NewMemberData] got request!");
            request.RequestValidation();
            _logger.LogInformation($"[NewMemberData] passed request validation.");
            if (await TheMemberDB.NewMember(request.objects[0].member))
            {
                response.code = 0;
                response.message = "Successfull.";
                return response;
            }
            else
            {
                response.code = -1;
                response.message = "Failed";
                return response;
            }
        }
        catch (Exception excp)
        {
            _logger.LogWarning(excp, "新增成員時候出例外。");
            response.code = -1;
            response.message = $"{excp.GetType()} - {excp.Message}";
            return response;
        }
    }
}