
using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class CreateGarageMenu : IMenu
{

    const string STAR_SEPARATOR = "*************************************";
    const string MENU_TITLE = "******** CREATE GARAGE MENU  ********";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";
    

    public static void StartMenu(GarageHandler gHandler)
    {

        Console.WriteLine("\n\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Please enter some information about your new garage.");
        Console.WriteLine(OPTION_QUIT);


        try
        {
            Console.WriteLine(LINE_SEPARATOR); 
            string garageName = GarageHandler.UserInputGarageName();


            Console.WriteLine(LINE_SEPARATOR); 
            int garageCapacity = GarageHandler.UserInputGarageCapacity();
        
            Console.WriteLine(LINE_SEPARATOR); 
            gHandler.CreateGarage(garageName,garageCapacity);

            Console.WriteLine($"Success! Garage {garageName} was created!");
            
        }
        catch (UserBackNavigationException) 
        {
            throw new UserBackNavigationException("No garage created!");
        }
        catch (UserTerminationException) 
        {
            throw;
        }
    }

}