using api_restfull_net8.Models;
using Microsoft.EntityFrameworkCore; // previamente se debe instalar los paquetes listados en el readme.md

namespace api_restfull_net8.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; }
}
