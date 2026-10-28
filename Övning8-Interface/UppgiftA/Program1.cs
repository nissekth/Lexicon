
namespace Övning8_Interface.UppgiftA;
public class Program1 : IStart, IExtra {
    
    /*
    public void Run()
    {
        Console.WriteLine("Nu kör vi program 1");
    }
    */


    public void Start()
    {
        Console.WriteLine("This is just start  (Program1)");
    }

    public void Extra()
    {
        Console.WriteLine("This is just extra (Program1)");
    }


}