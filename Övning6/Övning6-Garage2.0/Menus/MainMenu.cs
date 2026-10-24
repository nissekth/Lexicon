namespace Övning6_Garage2._0.Menus;

public class MainMenu
{
    const string SEPARATOR = "**************************************";
    const string MENU_TITLE = "***********   MAIN  MENU   ***********";
    const string OPTION_1 = "1: Park vehicle.";
    const string OPTION_2 = "2: Retrieve vehicle.";
    const string OPTION_3 = "3: List vehicles.";
    const string OPTION_4 = "4: Create garage.";
    const string OPTION_5 = "5: Switch garage.";
    const string OPTION_6 = "6: Populate garage with random vehicles.";
    const string OPTION_QUIT = "Press \'q\' to quit.";
    public static void StartMainMenu()
    {
        Console.WriteLine("\n\n"+SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(SEPARATOR);
        
        Console.WriteLine("Please select what you wish to do by entering a number below corresponding to your wish.");
        Console.WriteLine(OPTION_1);
        Console.WriteLine(OPTION_2);
        Console.WriteLine(OPTION_3);
        Console.WriteLine(OPTION_4);
        Console.WriteLine(OPTION_5);
        Console.WriteLine(OPTION_6);
        Console.WriteLine(OPTION_QUIT);
    }

    public static string? GetUserSelection()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }

}