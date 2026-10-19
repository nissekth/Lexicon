namespace Övning5_Garage1._0.Views;

public class MainView
{
    const string OPTION_1 = "1: Park vehicle.";
    const string OPTION_2 = "2: Retrieve vehicle.";
    const string OPTION_3 = "3: List vehicles.";
    public static void StartMainView()
    {
        Console.WriteLine(OPTION_1);
        Console.WriteLine(OPTION_2);
        Console.WriteLine(OPTION_3);
    }

    public static string? GetUserSelection()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }

}