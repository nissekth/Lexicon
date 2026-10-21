using System.Text.RegularExpressions;
using Övning5_Garage1._0.Enums;
using Övning5_Garage1._0.Exceptions;
using Övning5_Garage1._0.Models;

namespace Övning5_Garage1._0.Menus;

public class ParkVehicleMenu
{

    const string STAR_SEPARATOR = "********************************";
    const string MENU_TITLE = "*******  PARKING  MENU   *******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";
    public static void StartParkingMenu(Garage garage)
    {
        Console.WriteLine("\n\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Current garage is: " + garage.Name);
        Console.WriteLine(LINE_SEPARATOR);
        Console.WriteLine("Please enter some information about your vehicle by entering a number below corresponding to your wish.");
        Console.WriteLine(OPTION_QUIT);

        try
        {
            Vehicle? vehicle = CreateVehicle(garage);
            if(vehicle == null)
            {
                Console.WriteLine("Vehicle not parked.");
                return;
            }
            ParkVehicle(garage, vehicle);
        }
        catch (UserTerminationException e)
        {
            Console.WriteLine("Vehicle not parked! " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error!"+e.Message);
        }

    }

    private static Vehicle? CreateVehicle(Garage garage)
    {

        Vehicle vehicle;
        string registreringsnummer = "";
        VehicleType vehicleType = VehicleType.Undefined;
        VehicleColour vehicleColour = VehicleColour.Undefined;
        FuelType vehicleFuel = FuelType.Undefined;
        decimal vehicleLength = 0;


        //Determine vehicle type
        while (true)
        {    
            string? userInput = UserInputVehicleType();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter a type!");
                continue;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                return null;
            }

            int userSelection = -1;
            Boolean parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                //Hårdkodat, bör bytas senare till något kopplat till antal alternative
                if(userSelection < 1 || userSelection > 5)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 5!\n");
                }
                else
                {
                    vehicleType = (VehicleType)(userSelection-1);
                    Console.WriteLine();
                    break;
                }
            }
            Console.WriteLine($"Invalid option! Please provide an integer between 1 and 5!\n");
        }   


        //Determine registreringsnummer
        while (true)
        {
            Console.WriteLine(LINE_SEPARATOR); 
            string? userInput = UserInputRegistreringsnummer();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must enter something!");
                continue;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                return null;
            }

            try{
                registreringsnummer = FormatRegistreringsnummer(userInput);
                if (garage.RegistreringsnummerAlreadyInGarage(registreringsnummer))
                {
                    Console.WriteLine($"Vehicle with registreringsnummer {registreringsnummer} is already in the garage!");
                    return null;
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        } 

        //Determine colour
        while (true)
        {
            Console.WriteLine(LINE_SEPARATOR);   
            string? userInput = UserInputColour();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No colour selected.");
                break;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                return null;
            }

            int userSelection = -1;
            Boolean parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                //Hårdkodat, bör bytas senare till något kopplat till antal alternative
                if(userSelection < 1 || userSelection > 5)
                {
                    if(userSelection == 6)
                    {
                        break;
                    }
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 5!\n");
                }
                else
                {
                    vehicleColour = (VehicleColour)userSelection;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and 5!\n");
            }
        }
        
        Console.WriteLine(LINE_SEPARATOR);   


        //Determine Fueltype
        while (true)
        {    
            string? userInput = UserInputFuelType();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No fueltype selected.");
                break;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                return null;
            }

            int userSelection = -1;
            Boolean parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                //Hårdkodat, bör bytas senare till något kopplat till antal alternative
                if(userSelection < 1 || userSelection > 5)
                {
                    if(userSelection == 6)
                    {
                        break;
                    }
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 5!\n");
                }
                else
                {
                    vehicleFuel = (FuelType)userSelection;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and 5!\n");
            }
        }

        //Determine length
        while (true)
        {
            Console.WriteLine(LINE_SEPARATOR); 
            string? userInput = UserInputLength();
            Console.WriteLine(userInput);
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"No vehicle length specified.");
                break;
            }
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                return null;
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
                    vehicleLength = length;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an number!\n");
            }
        }
        
        Console.WriteLine(LINE_SEPARATOR);   

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
            default: throw new Exception("No such type!");
        }


    }

    private static string? UserInputVehicleType()
    {                
        //Hårdkodat, bör bytas senare till något kopplat till antal alternative
        Console.WriteLine("Please select the type of vehicle you wish to park by entering a number below corresponding to your vehicle type.");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i+1 + ": " + (VehicleType)(i));
        }
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? UserInputRegistreringsnummer()
    {
        Console.WriteLine("Please enter the registreringsnummer of the vehicle.");
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? UserInputColour()
    {
        //Hårdkodat, bör bytas senare till något kopplat till antal alternative
        Console.WriteLine("Please select the colour of the vehicle (optional).");        
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i+1 + ": " + (VehicleColour)(i));
        }
        Console.WriteLine("6. Unspecified.");
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? UserInputFuelType()
    {
        //Hårdkodat, bör bytas senare till något kopplat till antal alternative
        Console.WriteLine("Please select the fueltype of the vehicle (optional).");    
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i+1 + ": " + (FuelType)(i));
        }
        Console.WriteLine("6. Unspecified.");
        Console.Write("> ");
        return Console.ReadLine();
    }

    private static string? UserInputLength()
    {
        //Hårdkodat, bör bytas senare till något kopplat till antal alternative
        Console.WriteLine("Please enter the length of the vehicle in meters (optional)."); 
        Console.Write("> ");
        return Console.ReadLine();
    }


    private static void ParkVehicle(Garage garage, Vehicle vehicle){
        try
        {
            garage.ParkVehicle(vehicle);
            Console.WriteLine($"Successfully parked vehicle {vehicle.Registreringsnummer}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Could not park vehicle! {e.Message}");
        }

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

    private static string FormatRegistreringsnummer(string input){

        string reg = input ?? "error";
        reg = Regex.Replace(reg, @"\s", "");
                  
        if(reg.Length != 6)
        {
            throw new Exception("Registreringsnummer must consist of 6 characters.");
        }

        if (!char.IsDigit(reg.ElementAt(3)) || !char.IsDigit(reg.ElementAt(4)))
        {
            throw new Exception("Registreringsnummer must have integers at positions 3 and 4.");
        }

        return reg.ToUpper();;
    }
}