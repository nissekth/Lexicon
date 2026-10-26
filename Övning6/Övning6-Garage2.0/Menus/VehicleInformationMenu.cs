using Övning6_Garage2._0.Enums;
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Services;

namespace Övning6_Garage2._0.Menus;

public class VehicleInformationMenu
{

    const string STAR_SEPARATOR = "**************************************";
    const string MENU_TITLE = "****** VEHICLE INFORMATION MENU ******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_1 = "1: List details of a particular vehicle.";
    const string OPTION_2 = "2: List all vehicles; their type and their registreringsnummer.";
    const string OPTION_3 = "3: List vehicles based on properties.";
    const string OPTION_4 = "4: List the number of parked vehicles of each type the garage allows.";
    const string OPTION_QUIT = "Press \'q\' to quit and \'b\' to go back.\n";
    const int NUMBER_OF_OPTIONS = 4;

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


            try{
                int userSelection = SelectionService.UserInputSelection(1,NUMBER_OF_OPTIONS);

                if(userSelection == 1)
                {
                    Console.WriteLine(LINE_SEPARATOR); 
                    string registreringsnummer = VehicleService.UserInputRegistreringsnummer();

                    try{
                        Console.WriteLine(LINE_SEPARATOR);
                        Vehicle vehicle = garage.GetVehicleInformation(registreringsnummer);
                        Console.WriteLine($"Success! The following vehicle was retrieved:");
                        Console.WriteLine(vehicle.ListVehicleAttributes());
                    }
                    catch (NoSuchVehicleException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                        
                }
                else if (userSelection == 2)
                {
                    //Unneccessary to create this array, perhaps a bit encapsulation breaking?
                    //Ishould only request the information I actually need 
                    List<Vehicle> allParkedVehicles = garage.GetAllVehiclesInformation();
                    Console.WriteLine(LINE_SEPARATOR);
                    if(allParkedVehicles.Count < 1)
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
                }
                else if (userSelection == 3)
                {
                    Console.WriteLine(LINE_SEPARATOR);
                    PrintVehiclesFromCriteria(garage);
                }
                else if (userSelection == 4)
                {
                    List<int> garageStats = garage.GetGarageStats();
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
                }
            }
            catch (UserBackNavigationException) 
            {
                return;
            }
            catch (UserTerminationException) 
            {
                throw;
            }
        }
    }


    public static void PrintVehiclesFromCriteria(Garage garage)
    {
        try{
            VehicleType? vehicleType = InformationSearchService.DetermineVehicleType();
            VehicleColour? colour = InformationSearchService.DetermineVehicleColour();
            FuelType? fuelType = InformationSearchService.DetermineFuelType();
            int? noOfWheels = InformationSearchService.DetermineNoOfWheels();
            decimal? length = InformationSearchService.DetermineVehicleLength();
            
            List<Vehicle> vehicles = garage.GetGarageSelection(vehicleType, colour, fuelType, noOfWheels, length);

            if(vehicles.Count() > 0){

                Console.WriteLine(LINE_SEPARATOR);
                Console.Write($"Success! All vehicles matching search crietera (");
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
                Console.WriteLine(").");
                
                Console.WriteLine(LINE_SEPARATOR);
                foreach (Vehicle v in vehicles)
                {
                    Console.WriteLine($"{v.GetType().Name} {v.Registreringsnummer}");
                }
                Console.WriteLine(LINE_SEPARATOR);
            }
            else
            {
                Console.WriteLine(LINE_SEPARATOR);
                Console.WriteLine("No vehicles matching search criteria.");
            }
        }
        catch (UserBackNavigationException)
        {
            return;
        }
        catch (UserTerminationException)
        {
            throw;
        }
    }


}