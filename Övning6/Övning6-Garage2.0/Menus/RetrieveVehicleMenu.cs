using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Services;

namespace Övning6_Garage2._0.Menus;

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
        
        //Determine registreringsnummer
        try{
            Console.WriteLine(LINE_SEPARATOR);
            string? userInput = VehicleService.UserInputRegistreringsnummer();
            Vehicle vehicle = garage.RetrieveVehicle(userInput);
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