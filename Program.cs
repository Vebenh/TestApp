using Microsoft.EntityFrameworkCore;

using TestApp.EFTests;
using TestApp.Delegates;


class Program
{
    static void Main()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            // создаем два объекта User
            User user1 = new User { Name = "Tom", Age = 33 };
            User user2 = new User { Name = "Alice", Age = 26 };
            User user3 = new User { Name = "Alice", Age = 56 };

            // добавляем их в бд
            db.Users.AddRange(user1, user2, user3);
            db.SaveChanges();
        }

        getDbData();
        
        using (ApplicationContext db = new ApplicationContext() )
        {
            List<User> users = db.Users.Where(u => u.Name == "Alice").ToList();

            foreach (User user in users)
            {
                if (user.Age == 56)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    db.SaveChanges();
                }
            }
        }

        getDbData();
        deleteDbData(3);
        Console.ReadLine();
    }

    public static void getDbData()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            // получаем объекты из бд и выводим на консоль
            var users = db.Users.ToList();
            Console.WriteLine("Users list:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
            Console.WriteLine();
        }

    }

    public static void deleteDbData(int Id)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            // получаем первый объект
            User? user = db.Users.FirstOrDefault(u => u.Id == Id);
            if (user != null)
            {
                //удаляем объект
                db.Users.Remove(user);
                db.SaveChanges();
            }
            // выводим данные после обновления
            Console.WriteLine("\nДанные после удаления:");
            getDbData();
        }

    }
}