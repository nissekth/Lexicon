
using Övning6_Garage2._0.Enums;
using Övning6_Garage2._0.Exceptions;

namespace Övning6_Garage2._0.Services;

public class InformationSearchService
{
    
    public static VehicleType? DetermineVehicleType()
    {
        VehicleType? vehicleType = null;

        while(true){
            Console.WriteLine("Please enter vehicle type search criterion (optional):");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i + 1}: {(VehicleType)i}");
            }

            string? userInput = GetUserSelection();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No vehicle type search criterion!");
                break;
            }
            if (userInput == "q"){
                throw new UserTerminationException();
            }
            if (userInput == "b"){
                throw new UserBackNavigationException();
            }

            int userSelection = 0;
            bool parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 6)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 6!\n");
                    userSelection = 0;
                }
                else
                {
                    vehicleType = (VehicleType)(userSelection-1);
                    break;
                }
            }
            else
            {
                Console.WriteLine($"No vehicle type search criterion selected");
                break;
            }
        }

        return vehicleType;
        
    }


    public static FuelType? DetermineFuelType()
    {
        FuelType? fuelType = null;

        while(true){
            Console.WriteLine("Please enter vehicle fuel type search criterion (optional):");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i + 1}: {(FuelType)i}");
            }

            string? userInput = GetUserSelection();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No vehicle fuel type search criterion selected");
                break;
            }
            if (userInput == "q"){
                throw new UserTerminationException();
            }
            if (userInput == "b"){
                throw new UserBackNavigationException();
            }

            int userSelection = 0;
            bool parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 6)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 6!\n");
                    userSelection = 0;
                }
                else
                {
                    fuelType = (FuelType)(userSelection-1);
                    break;
                }
            }
            else
            {
                Console.WriteLine($"No vehicle fuel type search criterion selected");
                break;
            }
        }

        return fuelType;
        
    }



    public static VehicleColour? DetermineVehicleColour()
    {
        VehicleColour? vehicleColour = null;

        while(true){
            Console.WriteLine("Please enter vehicle colour search criterion (optional):");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i + 1}: {(VehicleColour)i}");
            }

            string? userInput = GetUserSelection();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No colour type search criterion selected.");
                break;
            }
            if (userInput == "q"){
                throw new UserTerminationException();
            }
            if (userInput == "b"){
                throw new UserBackNavigationException();
            }

            int userSelection = 0;
            bool parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 6)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 6!\n");
                    userSelection = 0;
                }
                else
                {
                    vehicleColour = (VehicleColour)(userSelection-1);
                    break;
                }
            }
            else
            {
                Console.WriteLine($"No vehicle colour selected.\n");
                break;
            }
        }

        return vehicleColour;
        
    }

    public static int? DetermineNoOfWheels()
    {
        int? noOfWheels = null;

        while(true){
            Console.WriteLine("Please enter number of wheels search criterion (optional):");

            string? userInput = GetUserSelection();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No vehicle number of wheels search criterion selected.");
                break;
            }
            if (userInput == "q"){
                throw new UserTerminationException();
            }
            if (userInput == "b"){
                throw new UserBackNavigationException();
            }

            int userSelection = 0;
            bool parseSuccess = int.TryParse(userInput, out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 6)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 6!\n");
                    userSelection = 0;
                }
                else
                {
                    noOfWheels = userSelection;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"No vehicle number of wheels search criterion selected.");
                break;
            }
        }

        return noOfWheels;
        
    }

    public static decimal? DetermineVehicleLength()
    {
        decimal? length = null;

        while(true){
            Console.WriteLine("Please enter vehicle max length search criterion in meters (optional):");

            string? userInput = GetUserSelection();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No vehicle max length search criterion selected.");
                break;
            }
            if (userInput == "q"){
                throw new UserTerminationException();
            }
            if (userInput == "b"){
                throw new UserBackNavigationException();
            }

            decimal userSelection = 0;
            bool parseSuccess = decimal.TryParse(userInput, out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 120)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 120!\n");
                    userSelection = 0;
                }
                else
                {
                    length = userSelection;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"No vehicle max length search criterion selected.");
                break;
            }
        }

        return length;
    }


    public static string? GetUserSelection()
    {
        Console.Write("> ");
        string? input = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(input))
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