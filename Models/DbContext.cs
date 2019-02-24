using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Models
{
  public class ChefContext : DbContext
  {
    public ChefContext(DbContextOptions<ChefContext> options) : base(options) { }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Dish> Dishes { get; set; }
  }
}