using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Models;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class RetrieveVehicleMenu : IMenu
{

    const string STAR_SEPARATOR = "***************************************";
    const string MENU_TITLE = "**********  RETRIEVAL MENU   **********";
    const string LINE_SEPARATOR = "_________________________________________";
    public static void StartMenu(GarageHandler gHandler)
    {
        Console.WriteLine("\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Current garage is: " + gHandler.CurrentGarage().Name);
        Console.WriteLine(LINE_SEPARATOR);

        //Determine licensePlate
        try{
            Console.WriteLine(LINE_SEPARATOR);
            string? userInput = VehicleHandler.UserInputLicensePlate();
            Vehicle vehicle = gHandler.CurrentGarage().RetrieveVehicle(userInput);
            Console.WriteLine(LINE_SEPARATOR);
            Console.WriteLine($"Success! The following vehicle was retrieved:");
            Console.WriteLine(vehicle.ListVehicleAttributes());
            return;
            
        } 
        catch (UserTerminationException) 
        {
            throw;
        }
        catch (UserBackNavigationException) 
        {
            return;
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

    private static void StartCheckout(Garage<Vehicle> garage)
    {
        

    }

}