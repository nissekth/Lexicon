using Övning6_Garage2._0.Enums;
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Services;

namespace Övning6_Garage2._0.Menus;

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
        try
        {        

            Console.WriteLine(LINE_SEPARATOR);   
            VehicleType vehicleType = VehicleService.UserInputVehicleType();

            Console.WriteLine(LINE_SEPARATOR);   
            string registreringsnummer = VehicleService.UserInputRegistreringsnummer();
            if (garage.RegistreringsnummerAlreadyInGarage(registreringsnummer))
            {
                Console.WriteLine($"Vehicle with registreringsnummer {registreringsnummer} is already in the garage!");
                return null;
            }

            Console.WriteLine(LINE_SEPARATOR);   
            VehicleColour vehicleColour = VehicleService.UserInputColour() ?? VehicleColour.Undefined;

            Console.WriteLine(LINE_SEPARATOR);   
            FuelType vehicleFuel = VehicleService.UserInputFuelType() ?? FuelType.Undefined;

            Console.WriteLine(LINE_SEPARATOR);   
            //Fix this to handle null everywhere, instead of defaulting to 0
            decimal vehicleLength = VehicleService.UserInputLength() ?? 0;

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
                    motorcycleBodyType = VehicleService.UserInputMotorcycleBodyType();
                    break;
                case VehicleType.Car: 
                    carBodyType = VehicleService.UserInputCarBodyType();
                    break;
                case VehicleType.Bus: 
                    noOfSeats = VehicleService.UserInputNoOfSeats();
                    break;
                case VehicleType.Boat: 
                    hasTrailer = VehicleService.UserInputTrailerPresence();
                    break;
                case VehicleType.Airplane: 
                    noOfEngines = VehicleService.UserInputNoOfEngines();
                    break;
                default: throw new Exception("Error! Vehicletype could not be determined.");
            }


            return VehicleCreator.CreateVehicle(vehicleType, registreringsnummer, vehicleColour, vehicleFuel, vehicleLength, motorcycleBodyType, carBodyType, noOfSeats, hasTrailer, noOfEngines);
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
}