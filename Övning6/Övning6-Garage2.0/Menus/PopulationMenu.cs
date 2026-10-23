using Övning6_Garage2._0.Enums;
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;

namespace Övning6_Garage2._0.Menus;

public class PopulationMenu
{
    const string SEPARATOR = "***************************************";
    const string MENU_TITLE = "******* INITIAL POPULATION MENU *******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";
    public static void PopulateGarage(Garage garage)
    {
        Console.WriteLine("\n\n"+SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(SEPARATOR);
        Console.WriteLine(LINE_SEPARATOR);
        Console.WriteLine($"Current garage is: {garage.Name} - Capacity: {garage.MaxCapacity}");

        if (garage.AvailableSlots < garage.MaxCapacity)
        {
            Console.WriteLine("Garage is not empty! Cannot populate non-empty garage.");
            return;
        }

        Console.WriteLine(OPTION_QUIT);


        while(true){
            Console.WriteLine("Please enter the number of vehicles you want created.");

            string? userInput = GetUserSelection();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter an integer!");
                continue;
            }
            if (UserQuitSignal(userInput)){
                throw new UserTerminationException();
            }
            if (UserBackNavigationSignal(userInput)){
                Console.WriteLine("No perfomed population of the garage.");
                return;
            }

            int userSelection = 0;
            bool parseSuccess = int.TryParse(userInput, out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > garage.MaxCapacity)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and {garage.MaxCapacity}!\n");
                    userSelection = 0;
                }
                else
                {
                    try
                    {
                        Random random = new();
                        //Skulle kunna fixa så att den, vid få available slots, bara randomiserar in valid vehicles.
                        //Fixa denna cast vid implementation av decimal sizes
                        int cap = Math.Min(userSelection, (int)garage.AvailableSlots);
                        int vehiclesAdded = 0;
                        while(cap > 0)
                        {
                            int maxSize = Math.Min(Enum.GetNames<VehicleType>().Length-1, (int)garage.AvailableSlots);
                            garage.ParkVehicle(CreateRandomVehicle(random, maxSize));
                            cap = Math.Min(userSelection-(++vehiclesAdded), (int)garage.AvailableSlots);
                        }
                        if(vehiclesAdded < userSelection)
                        {
                            Console.WriteLine("Garage full, cap was enforced.");
                        }
                        Console.WriteLine($"Success! Garage is populated with {vehiclesAdded} vehicles.");
                        return;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error! "+e.Message);
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine($"No vehicle colour selected.\n");
                break;
            }
        }
    }

    private static Vehicle CreateRandomVehicle(Random random, int maxSize)
    {
        Vehicle vehicle;
        VehicleType vehicleType = (VehicleType)random.Next(0, maxSize);
        string registreringsnummer = CreateRandomRegistreringsnummer(random);
        VehicleColour vehicleColour = (VehicleColour)random.Next(0, 6);
        FuelType vehicleFuel = (FuelType)random.Next(0, 6);
        decimal vehicleLength = random.Next(1, 120);

        switch (vehicleType)
        {
            case VehicleType.Car: 
                vehicle = new Car(VehicleType.Car, registreringsnummer, vehicleColour, vehicleFuel, 4, vehicleLength); 
                return vehicle;
            case VehicleType.Airplane: 
                vehicle = new Airplane(VehicleType.Airplane, registreringsnummer, vehicleColour, vehicleFuel, 6, vehicleLength);  
                return vehicle;
            case VehicleType.Boat: 
                vehicle = new Boat(VehicleType.Boat, registreringsnummer, vehicleColour, vehicleFuel, 0, vehicleLength);  
                return vehicle;
            case VehicleType.Bus: 
                vehicle = new Bus(VehicleType.Bus, registreringsnummer, vehicleColour, vehicleFuel, 6, vehicleLength);  
                return vehicle;
            case VehicleType.Motorcycle: 
                vehicle = new Motorcycle(VehicleType.Motorcycle, registreringsnummer, vehicleColour, vehicleFuel, 2, vehicleLength);  
                return vehicle;
            default: throw new Exception("No such vehicle type!");
        }
    }

    private static string CreateRandomRegistreringsnummer(Random random)
    {
        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
        string reg = "";

        for(int i = 0; i < 3; i++){
            reg += alfabet[random.Next(alfabet.Length)];
        }
        for(int i = 0; i < 3; i++){
            reg += random.Next(0, 10);
        }
        return reg;
    }

    private static string? GetUserSelection()
    {
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