
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;

namespace Övning6_Garage2._0.Menus;

public class SwitchGarageMenu
{

    const string STAR_SEPARATOR = "***************************************";
    const string MENU_TITLE = "********* SWITCH GARAGE MENU  *********";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";


    public static int? SwitchCurrentGarage(List<Garage> garages)
    {
        Console.WriteLine("\n\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Please enter which garage you would like to set as current.");
        Console.WriteLine(OPTION_QUIT);

        //Determine garage index
        while (true)
        {    
            Console.WriteLine(LINE_SEPARATOR); 

            string? userInput = UserSelectGarage(garages);
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must select a garage!");
                continue;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                Console.WriteLine("No garage created!");
                return null;
            }

            int userSelection = -1;
            Boolean parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                //Hårdkodat, bör bytas senare till något kopplat till antal alternative
                if(userSelection < 1 || userSelection > garages.Count)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer corresponding to the options!");
                }
                else
                {
                    Console.WriteLine($"Selecting {garages[userSelection-1].Name} as current garage.");
                    Console.WriteLine();
                    return userSelection-1;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer corresponding to the options!");
            }
        }   


    }

    private static string? UserSelectGarage(List<Garage> garages)
    {

        Console.WriteLine("Please enter which garage you would like to set as current.");
        for(int i = 0; i < garages.Count; i++)
        {
            Console.WriteLine($"{i+1}. {garages[i].Name} - Available slots: {garages[i].AvailableSlots}");
        }

        Console.Write("> ");
        return Console.ReadLine();

    }
    private static bool UserBackNavigationSignal(string str)
    {
        if(str == "b")
        {
            return true;
        }
        return false;
    }

    private static bool UserQuitSignal(string str)
    {
        if(str == "q")
        {
            return true;
        }
        return false;
    }

}