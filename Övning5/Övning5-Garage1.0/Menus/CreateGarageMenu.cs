
using Övning5_Garage1._0.Exceptions;
using Övning5_Garage1._0.Models;

namespace Övning5_Garage1._0.Menus;

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

        string garageName;
        int garageCapacity;


        //Determine garage name
        while (true)
        {   
            Console.WriteLine(LINE_SEPARATOR); 
            string? userInput = UserInputGarageName();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter a name!");
                continue;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                throw new Exception("No garage created!");
            }

            if(userInput.Length < 3 || userInput.Length > 20)
            {
                Console.WriteLine($"Invalid name! Please provide between 3 and 20 characters!\n");
            }
            else
            {
                garageName = userInput;
                break;
            }
        }

        //Determine capacity
        while (true)
        {
            Console.WriteLine(LINE_SEPARATOR); 
            string? userInput = UserInputCapacity();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter a capacity!");
                continue;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                throw new Exception("No garage created!");
            }
            
            int capacity = 0;
            Boolean parseSuccess = int.TryParse(userInput,out capacity);
            if (parseSuccess)
            {
                if(capacity < 1 || capacity > 100)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer capacity between 1 and 100!\n");
                }
                else
                {
                    garageCapacity = capacity;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an number!\n");
            }
        }
        
        Console.WriteLine(LINE_SEPARATOR); 

        Garage garage = new Garage(garageName,garageCapacity);
        Console.WriteLine($"Success! Garage {garageName} was created!");
        return garage;
    }


    private static string? UserInputGarageName()
    {
        Console.WriteLine("Please enter the name of the garage.");
        Console.Write("> ");
        return Console.ReadLine();
    }


    private static string? UserInputCapacity()
    {
        Console.WriteLine("Please enter the integer capacity of the garage."); 
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