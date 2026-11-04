using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Models;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class VehicleInformationMenu : IMenu
{

    const string STAR_SEPARATOR = "**************************************";
    const string MENU_TITLE = "****** VEHICLE INFORMATION MENU ******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_1 = "1: List details of a particular vehicle.";
    const string OPTION_2 = "2: List all vehicles; their type and their licensePlate.";
    const string OPTION_3 = "3: List vehicles based on properties.";
    const string OPTION_4 = "4: List the number of parked vehicles of each type the garage allows.";
    const string OPTION_QUIT = "Press \'q\' to quit and \'b\' to go back.\n";
    const int NUMBER_OF_OPTIONS = 4;

    public static void StartMenu(GarageHandler gHandler)
    {

        while(true){
            Console.WriteLine("\n\n"+STAR_SEPARATOR);
            Console.WriteLine(MENU_TITLE);
            Console.WriteLine(STAR_SEPARATOR);
            Console.WriteLine("Current garage is: " + gHandler.CurrentGarage().Name);
            Console.WriteLine(LINE_SEPARATOR);

            Console.WriteLine("Please select what you wish to do by entering a number below corresponding to your wish.");
            Console.WriteLine(OPTION_1);
            Console.WriteLine(OPTION_2);
            Console.WriteLine(OPTION_3);
            Console.WriteLine(OPTION_4);
            Console.WriteLine(OPTION_QUIT);


            try{
                int userSelection = SelectionHandler.UserInputSelection(1,NUMBER_OF_OPTIONS);

                if(userSelection == 1)
                {
                    Console.WriteLine(LINE_SEPARATOR); 
                    string licensePlate = VehicleHandler.UserInputLicensePlate();

                    try{
                        Console.WriteLine(LINE_SEPARATOR);
                        Vehicle vehicle = gHandler.CurrentGarage().GetVehicleInformation(licensePlate);
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
                    IEnumerable<Vehicle>? allParkedVehicles = gHandler.CurrentGarage().GetAllVehiclesInformation();
                    Console.WriteLine(LINE_SEPARATOR);
                    if(allParkedVehicles == null)
                    {
                        Console.WriteLine("Garage is empty!");
                    }
                    else
                    {
                        Console.WriteLine($"Success! All vehicles in garage:");
                        foreach(Vehicle v in allParkedVehicles)
                        {
                            Console.WriteLine($"{v.GetType().Name} {v.LicensePlate}");
                        }
                    }
                }
                else if (userSelection == 3)
                {
                    Console.WriteLine(LINE_SEPARATOR);
                    PrintVehiclesFromCriteria(gHandler.CurrentGarage());
                }
                else if (userSelection == 4)
                {
                    IReadOnlyDictionary<VehicleType,int> garageStats = gHandler.CurrentGarage().GetGarageStats();
                    Console.WriteLine(LINE_SEPARATOR);
                    foreach(var e in garageStats)
                    {
                        Console.WriteLine($"#{e.Key}: {e.Value}");
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


    public static void PrintVehiclesFromCriteria(Garage<Vehicle> garage)
    {
        try{
            VehicleType? vehicleType = InformationSearchHandler.DetermineVehicleType();
            VehicleColour? colour = InformationSearchHandler.DetermineVehicleColour();
            FuelType? fuelType = InformationSearchHandler.DetermineFuelType();
            int? noOfWheels = InformationSearchHandler.DetermineNoOfWheels();
            decimal? length = InformationSearchHandler.DetermineVehicleLength();
            
            IEnumerable<Vehicle> vehicles = garage.GetGarageSelection(vehicleType, colour, fuelType, noOfWheels, length);

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
                    Console.WriteLine($"{v.GetType().Name} {v.LicensePlate}");
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