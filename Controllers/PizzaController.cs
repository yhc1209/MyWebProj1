using Microsoft.AspNetCore.Mvc;
using myWebProj1.Utils;
using myWebProj1.Data;

namespace myWebProj1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController: ControllerBase
{
    private readonly ILogger<PizzaController> _logger;
    private readonly PizzaStoreDb _context;
    public PizzaController(ILogger<PizzaController> logger, PizzaStoreDb context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getPizzas")]
    public IResult GetPizzas()
    {
        // _logger.LogWarning("getPizzas!");
        try
        {
            Pizza[] pizzas = _context.PizzaMenu.ToArray();
            if (pizzas.Length == 0)
                return Results.NoContent();
            return Results.Json<Pizza[]>(pizzas);
        }
        catch (Exception excp)
        {
            string msg = "取得pizzas資料失敗。";
            _logger.LogError(excp, msg);
            return Results.Problem($"{msg} ({excp.GetType()} - {excp.Message})");
        }
    }

    [HttpGet("getPizza/{id}")]
    public async Task<IResult> GetPizza(int id)
    {
        _logger.LogWarning($"get Pizza#{id} information!");
        try
        {
            if (id < 0)
                return Results.BadRequest();

            Pizza? p = await _context.FindAsync<Pizza>(id);
            if (p is null)
                return Results.NotFound();
            return Results.Json<Pizza>(p);
        }
        catch (Exception excp)
        {
            string msg = "取得pizza資料失敗。";
            _logger.LogError(excp, msg);
            return Results.Problem($"{msg} ({excp.GetType()} - {excp.Message})");
        }
    }

    [HttpPost("newPizza")]
    public async Task<IResult> NewPizza(Pizza pizza)
    {
        try
        {
            if (pizza is null || String.IsNullOrWhiteSpace(pizza.Name))
                return Results.BadRequest();

            await _context.PizzaMenu.AddAsync(pizza);
            await _context.SaveChangesAsync();
            string msg = $"Create new pizza#{pizza.Id}";
            _logger.LogInformation(msg);
            return Results.Created<Pizza>(msg, pizza);
        }
        catch (Exception excp)
        {
            string msg = "新增pizza資料失敗。";
            _logger.LogError(excp, msg);
            return Results.Problem($"{msg} ({excp.GetType()} - {excp.Message})");
        }
    }

    [HttpPut("editPizza/{id}")]
    public async Task<IResult> EditPizza(int id, Pizza revision)
    {
        _logger.LogWarning("editPizza!");
        try
        {
            if (id < 0)
                return Results.BadRequest();
            if (revision is null || String.IsNullOrWhiteSpace(revision.Name))
                return Results.BadRequest();

            Pizza? p = await _context.PizzaMenu.FindAsync(id);
            if (p is null)
                return Results.NotFound();

            p.Name = revision.Name;
            p.Description = revision.Description;
            await _context.SaveChangesAsync();
            return Results.NoContent();
        }
        catch (Exception excp)
        {
            string msg = "編輯pizza資料失敗。";
            _logger.LogError(excp, msg);
            return Results.Problem($"{msg} ({excp.GetType()} - {excp.Message})");
        }
    }

    [HttpDelete("deletePizza/{id}")]
    public async Task<IResult> DeletePizza(int id)
    {
        _logger.LogWarning("deletePizza!");
        try
        {
            if (id < 0)
                return Results.BadRequest();

            Pizza? p = await _context.PizzaMenu.FindAsync(id);
            if (p is null)
                return Results.NotFound();

            _context.PizzaMenu.Remove(p);
            await _context.SaveChangesAsync();
            return Results.Ok<Pizza>(p);
        }
        catch (Exception excp)
        {
            string msg = "刪除pizza資料失敗。";
            _logger.LogError(excp, msg);
            return Results.Problem($"{msg} ({excp.GetType()} - {excp.Message})");
        }
    }
}