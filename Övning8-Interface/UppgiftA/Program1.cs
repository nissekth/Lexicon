
namespace Övning8_Interface.UppgiftA;
public class Program1 : IRun, IExtra {
    
    public void Run()
    {
        Console.WriteLine("Nu kör vi program 1");
    }

    public void Go()
    {
        
    }

    public void Extra()
    {
        Console.WriteLine("This is just extra");
    }

}