using Microsoft.EntityFrameworkCore;
using TestApp.EFTests;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = @"Server=127.0.0.1,2022;Database=TestDatabase;User=sa;Password=v2v3v5v8v9vfF;Encrypt=False";

        optionsBuilder.UseSqlServer(connectionString);
    }
}