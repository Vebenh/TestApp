using Microsoft.EntityFrameworkCore;

using TestApp.EFTests;
using TestApp.Delegates;


class Program
{
    static void Main()
    {
        using (var dbContext = new ApplicationContext())
        {
            try
            {
                var serverVersion = dbContext.Database.ExecuteSqlRaw("SELECT @@VERSION").ToString();
                Console.WriteLine($"Подключение успешно! Версия сервера: {serverVersion}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения к базе данных: {ex.Message}");
            }
        }

        Console.ReadLine();
    }
}