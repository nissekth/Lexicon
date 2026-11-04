
using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Models;

namespace Övning9_Garage3._0.Handlers;

public class GarageHandler
{
    const int GARAGE_CAPACITY_CEILING = 800;

    public List<Garage<Vehicle>> garages { get; private set; } = [new ("Default Garage",20)];
    public int currentGarageIndex { get; private set; } = 0;

    public void CreateGarage(string name, int capacity)
    {
        garages.Add(new Garage<Vehicle>(name,capacity));
        currentGarageIndex = garages.Count - 1;
    }

    public Garage<Vehicle> CurrentGarage()
    {
        return garages.ElementAt(currentGarageIndex);
    }

    public int GaragesCount()
    {
        return garages.Count();
    }

    public IEnumerable<Garage<Vehicle>> GetGarages()
    {
        return garages;
    }

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


    public void SwitchGarage(){
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

            bool parseSuccess = int.TryParse(userInput,out int userSelection);
            if (parseSuccess)
            {
                //Hårdkodat, bör bytas senare till något kopplat till antal alternative
                if(userSelection < 1 || userSelection > garages.Count())
                {
                    Console.WriteLine($"Invalid option! Please provide an integer corresponding to the options!");
                }
                else
                {
                    currentGarageIndex = userSelection-1;
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer corresponding to the options!");
            }
        }   
    }


    private static string? UserSelectGarage(IEnumerable<Garage<Vehicle>> garages)
    {

        Console.WriteLine("Please enter which garage you would like to set as current.");
        for(int i = 0; i < garages.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {garages.ElementAt(i).Name} - Available slots: {garages.ElementAt(i).AvailableSlots}");
        }

        Console.Write("> ");
        return Console.ReadLine();

    }
}