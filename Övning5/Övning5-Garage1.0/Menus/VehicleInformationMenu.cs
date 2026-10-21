using System.Text.RegularExpressions;
using Övning5_Garage1._0.Enums;
using Övning5_Garage1._0.Exceptions;
using Övning5_Garage1._0.Models;

namespace Övning5_Garage1._0.Menus;

public class VehicleInformationMenu
{

    const string STAR_SEPARATOR = "**************************************";
    const string MENU_TITLE = "****** VEHICLE INFORMATION MENU ******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_1 = "1: List details of a particular vehicle.";
    const string OPTION_2 = "2: List all vehicles; their type and their registreringsnummer.";
    const string OPTION_3 = "3: List type and registreringsnummer of a selection of vehicles.";
    const string OPTION_4 = "4: List the number of parked vehicles of each type the garage allows.";
    const string OPTION_QUIT = "Press \'q\' to quit and \'b\' to go back.\n";

    public static void StartInformationMenu(Garage garage)
    {


        while(true){
            Console.WriteLine("\n\n"+STAR_SEPARATOR);
            Console.WriteLine(MENU_TITLE);
            Console.WriteLine(STAR_SEPARATOR);
            Console.WriteLine("Current garage is: " + garage.Name);
            Console.WriteLine(LINE_SEPARATOR);

            Console.WriteLine("Please select what you wish to do by entering a number below corresponding to your wish.");
            Console.WriteLine(OPTION_1);
            Console.WriteLine(OPTION_2);
            Console.WriteLine(OPTION_3);
            Console.WriteLine(OPTION_4);
            Console.WriteLine(OPTION_QUIT);





            
            int userSelection = 0;

            string? input = GetUserSelection();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"You must select an option below or go back.");
                break;
            }
            if (UserQuitSignal(input))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(input))
            {
                return;
            }

            bool parseSuccess = int.TryParse(input,out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 4)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 4!\n");
                    userSelection = 0;
                    continue;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and 4!\n");
            }

            if(userSelection == 1)
            {
                //Determine registreringsnummer
                while (true)
                {
                    Console.WriteLine(LINE_SEPARATOR); 
                    string? userInput = UserInputRegistreringsnummer();
                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine($"You must enter a registreringsnummer!");
                        continue;
                    }
                    if (UserQuitSignal(userInput))
                    {
                        throw new UserTerminationException();
                    }
                    if (UserBackNavigationSignal(userInput))
                    {
                        break;
                    }

                    try{
                        if(!ValidRegistreringsnummer(userInput))
                        {
                            Console.WriteLine($"{userInput} is not a valid registreringsnummer.");
                        }
                        else
                        {
                            Console.WriteLine(LINE_SEPARATOR);
                            Vehicle vehicle = garage.GetVehicleInformation(userInput);
                            Console.WriteLine($"Success! The following vehicle was retrieved:");
                            Console.WriteLine(vehicle.ListVehicleAttributes());
                            return;
                        }
                    }
                    catch (NoSuchVehicleException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                } 
            }
            else if (userSelection == 2)
            {
                //Unneccessary to create this array, perhaps a bit encapsulation breaking?
                //Ishould only request the information I actually need 
                Vehicle[] allParkedVehicles = garage.GetAllVehiclesInformation();
                Console.WriteLine(LINE_SEPARATOR);
                if(allParkedVehicles.Length < 1)
                {
                    Console.WriteLine("Garage is empty!");
                }
                else
                {
                    Console.WriteLine($"Success! All vehicles in garage:");
                    foreach(Vehicle v in allParkedVehicles)
                    {
                        Console.WriteLine($"{v.GetType().Name} {v.Registreringsnummer}");
                    }
                }
                Console.WriteLine(LINE_SEPARATOR);
            }
            else if (userSelection == 3)
            {
                VehicleType? vehicleType = DetermineVehicleType();
                VehicleColour? colour = DetermineVehicleColour();
                FuelType? fuelType = DetermineFuelType();
                int? noOfWheels = DetermineNoOfWheels();
                decimal? length = DetermineVehicleLength();
                
                Vehicle[] vehicles = garage.GetGarageSelection(vehicleType, colour, fuelType, noOfWheels, length);

                if(vehicles.Any()){

                    Console.WriteLine(LINE_SEPARATOR);
                    Console.Write($"Success! All vehicles matching search crietera ");
                    if (vehicleType != null)
                    {
                        Console.Write($"Type: {vehicleType} ");   
                    }
                    if (colour != null)
                    {
                        Console.Write($"Colour: {colour} ");
                    }
                    if (fuelType != null)
                    {
                        Console.Write($"Fuel: {fuelType} ");
                    }
                    if (noOfWheels != null)
                    {
                        Console.Write($"Wheels: {noOfWheels} ");
                    }
                    if (length != null)
                    {
                        Console.Write($"Length: {length} ");
                    }
                    Console.WriteLine(".");
                    
                    foreach (Vehicle v in vehicles)
                    {
                        if(v != null)
                        {
                            Console.WriteLine($"{v.GetType().Name} {v.Registreringsnummer}");
                        }
                    }
                    Console.WriteLine(LINE_SEPARATOR);
                }
                else
                {
                    Console.WriteLine("No vehicles mathing search criteria.");
                }
            }
            else if (userSelection == 4)
            {
                int[] garageStats = garage.GetGarageStats();
                bool empty = true;
                foreach (int vehicleStat in garageStats)
                {
                    if (vehicleStat > 0)
                    {
                        empty = false;
                        break;
                    }
                }

                Console.WriteLine(LINE_SEPARATOR);
                if(empty)
                {
                    Console.WriteLine("Garage is empty!");
                }
                else
                {
                    int i = 0;
                    foreach(int e in garageStats)
                    {
                        Console.WriteLine($"#{(VehicleType)i++}: {e}");
                    }
                }
                Console.WriteLine(LINE_SEPARATOR);
            }
        }
    }




    public static string? GetUserSelection()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }


    //Myckt kodrepetition här och nedan.
    private static VehicleType? DetermineVehicleType()
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
            if (UserQuitSignal(userInput)){
                throw new UserTerminationException();
            }
            if (UserBackNavigationSignal(userInput)){
                return null;
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


    private static FuelType? DetermineFuelType()
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
            if (UserQuitSignal(userInput)){
                throw new UserTerminationException();
            }
            if (UserBackNavigationSignal(userInput)){
                return null;
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



    private static VehicleColour? DetermineVehicleColour()
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
            if (UserQuitSignal(userInput)){
                throw new UserTerminationException();
            }
            if (UserBackNavigationSignal(userInput)){
                return null;
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

    private static int? DetermineNoOfWheels()
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
            if (UserQuitSignal(userInput)){
                throw new UserTerminationException();
            }
            if (UserBackNavigationSignal(userInput)){
                return null;
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

    private static decimal? DetermineVehicleLength()
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
            if (UserQuitSignal(userInput)){
                throw new UserTerminationException();
            }
            if (UserBackNavigationSignal(userInput)){
                return null;
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

    

    
    private static bool ValidRegistreringsnummer(string input){

        string reg = input ?? "error";
        reg = Regex.Replace(reg, @"\s", "");
                  
        if(reg.Length != 6)
        {
            return false;
        }

        if (!char.IsDigit(reg.ElementAt(3)) || !char.IsDigit(reg.ElementAt(4)))
        {
            return false;
        }

        return true;
    }


    private static string? UserInputRegistreringsnummer()
    {
        Console.WriteLine("Please enter the registreringsnummer of the vehicle.");
        Console.WriteLine("Press \'q\' to quit or \'b\' to go back.");
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