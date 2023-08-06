using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using TestApp.EFTests;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(getConfig("DefaultConnection")) ;
    }

    protected string getConfig(string ConnectionType)
    {
        var builder = new ConfigurationBuilder();
        // установка пути к текущему каталогу
        string appsettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

        //Console.WriteLine(appsettingsPath);
        //Console.ReadLine();
        // получаем конфигурацию из файла appsettings.json
        builder.AddJsonFile(appsettingsPath);
        // создаем конфигурацию
        var config = builder.Build();
        // получаем строку подключения
        return config.GetConnectionString(ConnectionType);
    }
}