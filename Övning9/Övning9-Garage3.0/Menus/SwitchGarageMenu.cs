
using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class SwitchGarageMenu : IMenu
{

    const string STAR_SEPARATOR = "***************************************";
    const string MENU_TITLE = "********* SWITCH GARAGE MENU  *********";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";


    public static void StartMenu(GarageHandler gHandler)
    {
        Console.WriteLine("\n\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Please enter which garage you would like to set as current.");
        Console.WriteLine(OPTION_QUIT);

        try
        {
            //int userSelection = SelectionHandler.UserInputSelection(1, gHandler.GaragesCount());
            gHandler.SwitchGarage();
            Console.WriteLine($"Selected {gHandler.CurrentGarage().Name} as current garage.");
        }
        catch (UserTerminationException) 
        {
            throw;
        }
        catch (UserBackNavigationException) 
        {
            throw;
        }
    }

}