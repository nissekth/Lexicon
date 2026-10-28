


namespace Övning8_Interface;
public class MainP {
    
    public static void Main()
    {
        
        UppgiftA.Program1 Aprog1 = new UppgiftA.Program1();
        UppgiftA.Program2 Aprog2 = new UppgiftA.Program2();
        //Aprog1.Run();
        //Aprog2.Go();
        Aprog1.Start();
        Aprog2.Start();
        Aprog1.Extra();


        UppgiftB.Program BProg = new UppgiftB.Program();

        UppgiftB.IRun1 Bprog1 = BProg;
        UppgiftB.IRun2 Bprog2 = BProg;
        Bprog1.Run();
        Bprog2.Run();

    }

}