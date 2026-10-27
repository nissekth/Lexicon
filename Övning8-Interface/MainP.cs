


namespace Övning8_Interface;
public class MainP {
    
    public static void Main()
    {
        
        UppgiftA.Program1 Aprog1 = new UppgiftA.Program1();
        UppgiftA.Program2 Aprog2 = new UppgiftA.Program2();
        Aprog1.Run();
        Aprog2.Go();
        Aprog1.Extra();

        UppgiftB.IProgram1 Bprog1 = new UppgiftB.Program();
        UppgiftB.IProgram2 Bprog2 = new UppgiftB.Program();
        Bprog1.Run();
        Bprog2.Run();

    }

}