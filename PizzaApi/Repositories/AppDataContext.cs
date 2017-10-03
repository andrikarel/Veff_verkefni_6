using Microsoft.EntityFrameworkCore;
using PizzaApi.Models.EntityModels;

namespace PizzaApi.Repositories
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems {get; set;}
        public DbSet<Order> Order {get; set;}
        public DbSet<OrderLink> OrderLink {get; set;}

    }
}