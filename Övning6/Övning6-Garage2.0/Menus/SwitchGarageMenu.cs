
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Services;

namespace Övning6_Garage2._0.Menus;

public class SwitchGarageMenu
{

    const string STAR_SEPARATOR = "***************************************";
    const string MENU_TITLE = "********* SWITCH GARAGE MENU  *********";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";


    public static int SwitchCurrentGarage(List<Garage> garages)
    {
        Console.WriteLine("\n\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Please enter which garage you would like to set as current.");
        Console.WriteLine(OPTION_QUIT);

        try
        {
            int index = GarageService.UserInputGarageIndex(garages);
            Console.WriteLine($"Selecting {garages[index].Name} as current garage.");
            return index;
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