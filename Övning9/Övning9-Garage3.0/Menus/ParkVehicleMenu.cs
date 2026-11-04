using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Models;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class ParkVehicleMenu : IMenu
{

    const string STAR_SEPARATOR = "********************************";
    const string MENU_TITLE = "*******  PARKING  MENU   *******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";
    public static void StartMenu(GarageHandler gHandler)
    {
        Console.WriteLine("\n\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Current garage is: " + gHandler.CurrentGarage().Name);
        Console.WriteLine(LINE_SEPARATOR);
        Console.WriteLine("Please enter some information about your vehicle by entering a number below corresponding to your wish.");
        Console.WriteLine(OPTION_QUIT);

        try
        {
            Vehicle? vehicle = CreateVehicle(gHandler.CurrentGarage());
            if(vehicle == null)
            {
                Console.WriteLine("Vehicle not parked.");
                return;
            }
            ParkVehicle(gHandler.CurrentGarage(), vehicle);
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

    private static Vehicle? CreateVehicle(Garage<Vehicle> garage)
    {
        try
        {        

            Console.WriteLine(LINE_SEPARATOR);   
            VehicleType vehicleType = VehicleHandler.UserInputVehicleType();

            Console.WriteLine(LINE_SEPARATOR);   
            string licensePlate = VehicleHandler.UserInputLicensePlate();
            if (garage.VehicleInGarage(licensePlate))
            {
                Console.WriteLine($"Vehicle with licensePlate {licensePlate} is already in the garage!");
                return null;
            }

            Console.WriteLine(LINE_SEPARATOR);   
            VehicleColour vehicleColour = VehicleHandler.UserInputColour() ?? VehicleColour.Undefined;

            Console.WriteLine(LINE_SEPARATOR);   
            FuelType vehicleFuel = VehicleHandler.UserInputFuelType() ?? FuelType.Undefined;

            Console.WriteLine(LINE_SEPARATOR);   
            //Fix this to handle null everywhere, instead of defaulting to 0
            decimal vehicleLength = VehicleHandler.UserInputLength() ?? 0;

            //handle subclass specific properties
            Console.WriteLine(LINE_SEPARATOR);
            MotorcycleBodyType? motorcycleBodyType = null;
            CarBodyType? carBodyType = null;
            int? noOfSeats = null;
            bool? hasTrailer = null;
            int? noOfEngines = null;
            switch (vehicleType)
            {
                case VehicleType.Motorcycle: 
                    motorcycleBodyType = VehicleHandler.UserInputMotorcycleBodyType();
                    break;
                case VehicleType.Car: 
                    carBodyType = VehicleHandler.UserInputCarBodyType();
                    break;
                case VehicleType.Bus: 
                    noOfSeats = VehicleHandler.UserInputNoOfSeats();
                    break;
                case VehicleType.Boat: 
                    hasTrailer = VehicleHandler.UserInputTrailerPresence();
                    break;
                case VehicleType.Airplane: 
                    noOfEngines = VehicleHandler.UserInputNoOfEngines();
                    break;
                default: throw new Exception("Error! Vehicletype could not be determined.");
            }


            return VehicleCreator.CreateVehicle(vehicleType, licensePlate, vehicleColour, vehicleFuel, vehicleLength, motorcycleBodyType, carBodyType, noOfSeats, hasTrailer, noOfEngines);
        }
        catch (UserTerminationException)
        {
            throw;
        }
        catch (UserBackNavigationException)
        {
            throw;
        }
    }


    private static void ParkVehicle(Garage<Vehicle> garage, Vehicle vehicle){
        try
        {
            garage.ParkVehicle(vehicle);
            Console.WriteLine($"Successfully parked vehicle {vehicle.LicensePlate}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Could not park vehicle! {e.Message}");
        }

    }
}