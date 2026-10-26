
using Övning6_Garage2._0.Exceptions;

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
}