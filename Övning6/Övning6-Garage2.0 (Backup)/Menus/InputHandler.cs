using System.Text.RegularExpressions;
using Övning6_Garage2._0.Enums;
using Övning6_Garage2._0.Exceptions;

namespace Övning6_Garage2._0.Menus;

public class InputHandler
{
    public static VehicleType UserInputVehicleType()
    {

        //Determine vehicle type
        while (true)
        {    
            string? userInput = PromptVehicleType();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter a type!");
                continue;
            }
            //Probably bad practice, fix later
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
            int noOfVehicleTypes = Enum.GetValues<VehicleType>().Length-1;
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > noOfVehicleTypes)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and {noOfVehicleTypes}!\n");
                }
                else
                {
                    return (VehicleType)(userSelection-1);
                }
            }
            Console.WriteLine($"Invalid option! Please provide an integer between 1 and {noOfVehicleTypes}!\n");
        }   
        
    }

    public static string UserInputRegistreringsnummer()
    {
        string registreringsnummer = "";
        //Determine registreringsnummer
        while (true)
        {
            string? userInput = PromptRegistreringsnummer();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter something!");
                continue;
            }
            //Probably bad practice, fix later
            if (userInput == "q")
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (userInput == "b")
            {
                throw new UserBackNavigationException();
            }

            try{
                registreringsnummer = FormatRegistreringsnummer(userInput);
                return registreringsnummer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        } 
    }

    public static VehicleColour? UserInputColour()
    {
        //Determine colour
        while (true)
        {
            string? userInput = PromptVehicleColour();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No colour selected.");
                return null;
            }
            //Probably bad practice, fix later
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
            int noOfColourTypes = Enum.GetValues<VehicleColour>().Length-1;
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > noOfColourTypes)
                {
                    if(userSelection == 6)
                    {
                return null;
                    }
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and {noOfColourTypes}!\n");
                }
                else
                {
                    return (VehicleColour)userSelection;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and {noOfColourTypes}!\n");
            }
        }
    }
         
    public static FuelType? UserInputFuelType()
    {

        //Determine Fueltype
        while (true)
        {    
            string? userInput = PromptVehicleFuelType();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No fueltype selected.");
                return null;
            }
            //Probably bad practice, fix later
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
            int noOfFuelTypes = Enum.GetValues<VehicleColour>().Length-1;
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > noOfFuelTypes)
                {
                    if(userSelection == 6)
                    {
                        return null;
                    }
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and {noOfFuelTypes}!\n");
                }
                else
                {
                    return (FuelType)userSelection;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and {noOfFuelTypes}!\n");
            }
        }
    }

    public static decimal? UserInputLength()
    {
        //Determine length
        while (true)
        {
            string? userInput = PromptVehicleLength();
            Console.WriteLine(userInput);
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No vehicle length specified.");
                return null;
            }
            //Probably bad practice, fix later
            if (userInput == "q")
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (userInput == "b")
            {
                throw new UserBackNavigationException();
            }
            
            decimal length = 0;
            Boolean parseSuccess = decimal.TryParse(userInput,out length);
            if (parseSuccess)
            {
                //Hårdkodat, bör bytas senare till något kopplat till antal alternative
                if(length < 1 || length > 100)
                {
                    Console.WriteLine($"Invalid option! Please provide the length of your vehicle!\n");
                }
                else
                {
                    return length;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an number!\n");
            }
        }
    }

    private static string? PromptVehicleType()
    {                
        Console.WriteLine("Please select the type of vehicle you wish to park by entering a number below corresponding to your vehicle type.");
        int noOfVehicleTypes = Enum.GetValues<VehicleType>().Length-1;
        for (int i = 0; i < noOfVehicleTypes; i++)
        {
            Console.WriteLine(i+1 + ": " + (VehicleType)(i));
        }
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? PromptRegistreringsnummer()
    {
        Console.WriteLine("Please enter the registreringsnummer of the vehicle.");
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? PromptVehicleColour()
    {
        Console.WriteLine("Please select the colour of the vehicle (optional).");  
        int noOfVehicleColours = Enum.GetValues<VehicleColour>().Length-1;      
        for (int i = 0; i < noOfVehicleColours; i++)
        {
            Console.WriteLine(i+1 + ": " + (VehicleColour)(i));
        }
        Console.WriteLine("6. Unspecified.");
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? PromptVehicleFuelType()
    {
        Console.WriteLine("Please select the fueltype of the vehicle (optional).");   
        int noOfFuelTypes = Enum.GetValues<FuelType>().Length-1; 
        for (int i = 0; i < noOfFuelTypes; i++)
        {
            Console.WriteLine(i+1 + ": " + (FuelType)(i));
        }
        Console.WriteLine("6. Unspecified.");
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? PromptVehicleLength()
    {
        //Hårdkodat, bör bytas senare till något kopplat till antal alternative
        Console.WriteLine("Please enter the length of the vehicle in meters (optional)."); 
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string FormatRegistreringsnummer(string input){

        string reg = input ?? "error";
        reg = Regex.Replace(reg, @"\s", "");
                  
        if(reg.Length != 6)
        {
            throw new Exception("Registreringsnummer must consist of 6 characters.");
        }

        if (!char.IsLetter(reg.ElementAt(1)) || !char.IsLetter(reg.ElementAt(2) || !char.IsLetter(reg.ElementAt(3))))
        {
            throw new Exception("Registreringsnummer must have letters at positions 1 2, and 3.");
        }

        if (!char.IsDigit(reg.ElementAt(3)) || !char.IsDigit(reg.ElementAt(4)))
        {
            throw new Exception("Registreringsnummer must have integers at positions 3 and 4.");
        }

        return reg.ToUpper();
    }

    public static string? GetUserSelection()
    {
        Console.Write("> ");
        string? input = Console.ReadLine();

        if(input == null)
        {
            return null;
        }
        if (input == "q")
        {
            throw new UserTerminationException();
        }
        if (input == "b")
        {
            throw new UserBackNavigationException();
        }
        return input;
    }

}