
namespace Övning8_Interface.UppgiftB;
public class Program : IProgram1, IProgram2  {
    
    void IProgram1.Run()
    {
        Console.WriteLine("Nu kör vi void Run()");
    }


    int IProgram2.Run()
    {
        Console.WriteLine("Nu kör vi int Run()");
        return 7;
    }
}