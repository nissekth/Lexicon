
namespace Övning8_Interface.UppgiftB;
public class Program : IRun1, IRun2  {
    
    void IRun1.Run()
    {
        Console.WriteLine("Nu kör vi void Run() (IRun1)");
    }


    int IRun2.Run()
    {
        Console.WriteLine("Nu kör vi int Run() (IRun2)");
        return 7;
    }
}