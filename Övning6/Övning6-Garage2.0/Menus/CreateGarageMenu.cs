
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Services;

namespace Övning6_Garage2._0.Menus;

public class CreateGarageMenu
{

    const string STAR_SEPARATOR = "*************************************";
    const string MENU_TITLE = "******** CREATE GARAGE MENU  ********";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";
    

    public static Garage CreateNewGarage()
    {

        Console.WriteLine("\n\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Please enter some information about your new garage.");
        Console.WriteLine(OPTION_QUIT);


        try
        {
            Console.WriteLine(LINE_SEPARATOR); 
            string garageName = GarageService.UserInputGarageName();


            Console.WriteLine(LINE_SEPARATOR); 
            int garageCapacity = GarageService.UserInputGarageCapacity();
        
            Console.WriteLine(LINE_SEPARATOR); 
            Garage garage = new Garage(garageName,garageCapacity);

            Console.WriteLine($"Success! Garage {garageName} was created!");
            return garage;
            
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