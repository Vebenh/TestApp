using TestApp.Delegates;

class Program
{
    static void Main()
    {
        new Delegates(Console.ReadLine(), Console.ReadLine(), 10, 5, Delegates.Operations.Mult);
        Console.ReadLine();

    }
}
