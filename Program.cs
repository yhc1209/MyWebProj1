using Microsoft.EntityFrameworkCore;
using myWebProj1.Data;
using myWebProj1.Utils;

if (Cmd.DoCmdAction(args))
    return;

var builder = WebApplication.CreateBuilder(args);
string comStr = builder.Configuration.GetConnectionString("Pizza") ?? "";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PizzaStoreDb>(op => { op.UseNpgsql(comStr); });

var app = builder.Build();

if (Cmd.DoUpdateDB)
{
    try
    {
        using (var scope = app.Services.CreateScope())
        using (var db = scope.ServiceProvider.GetRequiredService<PizzaStoreDb>())
            db.Database.Migrate();
        Console.WriteLine("完成database migration。");
    }
    catch (Exception excp)
    {
        Console.WriteLine($"更新database時出例外。\n{excp.GetType()} - {excp.Message}");
    }

    return;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}"
);
app.MapFallbackToFile("index.html");
app.Run();