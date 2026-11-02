using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Models;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class RetrieveVehicleMenu
{

    const string STAR_SEPARATOR = "***************************************";
    const string MENU_TITLE = "**********  RETRIEVAL MENU   **********";
    const string LINE_SEPARATOR = "_________________________________________";
    public static void StartRetrievalMenu(Garage garage)
    {
        Console.WriteLine("\n"+STAR_SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(STAR_SEPARATOR);
        Console.WriteLine("Current garage is: " + garage.Name);
        Console.WriteLine(LINE_SEPARATOR);

        StartCheckout(garage);
    }

    private static void StartCheckout(Garage garage)
    {
        
        //Determine licensePlate
        try{
            Console.WriteLine(LINE_SEPARATOR);
            string? userInput = VehicleHandler.UserInputLicensePlate();
            Vehicle vehicle = garage.RetrieveVehicle(userInput);
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

}