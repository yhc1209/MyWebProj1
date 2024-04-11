using Microsoft.EntityFrameworkCore;

namespace myWebProj1.Data;

public class PizzaStoreDb: DbContext
{
    public PizzaStoreDb(DbContextOptions options): base(options) {}
    public DbSet<Pizza> PizzaMenu { get; set; } = null!;
}