
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;

namespace Övning6_Garage2._0.Services;

public class GarageService
{
    const int GARAGE_CAPACITY_CEILING = 200;

    public static string UserInputGarageName()
    {
        //Determine garage name
        while (true)
        {   
            string? userInput = PromptGarageName();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter a name!");
                continue;
            }
            if (userInput == "q")
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (userInput == "b")
            {
                throw new UserBackNavigationException();
            }

            if(userInput.Length < 3 || userInput.Length > 20)
            {
                Console.WriteLine($"Invalid name! Please provide between 3 and 20 characters!\n");
            }
            else
            {
                return userInput;
            }
        }
    }

    public static int UserInputGarageCapacity()
    {
    
        //Determine capacity
        while (true)
        {
            string? userInput = PromptGarageCapacity();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter a capacity!");
                continue;
            }
            if (userInput == "q")
            {
                throw new UserTerminationException();
            }
            if (userInput == "b")
            {
                throw new UserBackNavigationException();
            }
            
            int capacity = 0;
            Boolean parseSuccess = int.TryParse(userInput,out capacity);
            if (parseSuccess)
            {
                if(capacity < 1 || capacity > GARAGE_CAPACITY_CEILING)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer capacity between 1 and {GARAGE_CAPACITY_CEILING}!\n");
                }
                else
                {
                    return capacity;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an number!\n");
            }
        }
    }

    private static string? PromptGarageName()
    {
        Console.WriteLine("Please enter the name of the garage.");
        Console.Write("> ");
        return Console.ReadLine();
    }


    private static string? PromptGarageCapacity()
    {
        Console.WriteLine("Please enter the integer capacity of the garage."); 
        Console.Write("> ");
        return Console.ReadLine();
    }


    public static int UserInputGarageIndex(List<Garage> garages){
        //Determine garage index
        while (true)
        {  

            string? userInput = UserSelectGarage(garages);
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must select a garage!");
                continue;
            }
            if (userInput == "q")
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (userInput == "b")
            {
                throw new UserBackNavigationException();
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
}