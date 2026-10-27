
namespace Övning8_Interface.UppgiftB;
public class Program : IRun1, IRun2  {
    
    void IRun1.Run()
    {
        Console.WriteLine("Nu kör vi void Run()");
    }


    int IRun2.Run()
    {
        Console.WriteLine("Nu kör vi int Run()");
        return 7;
    }
}