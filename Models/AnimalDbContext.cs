using FarmManagementApi.Models;
using Microsoft.EntityFrameworkCore;

public class AnimalDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }

    public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
    {
    }
}