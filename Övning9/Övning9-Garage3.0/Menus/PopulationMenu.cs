using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Models;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class PopulationMenu : IMenu
{
    const string SEPARATOR = "***************************************";
    const string MENU_TITLE = "******* INITIAL POPULATION MENU *******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";
    public static void StartMenu(GarageHandler gHandler)
    {
        Console.WriteLine("\n\n"+SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(SEPARATOR);
        Console.WriteLine(LINE_SEPARATOR);
        Console.WriteLine($"Current garage is: {gHandler.CurrentGarage().Name} - Capacity: {gHandler.CurrentGarage().MaxCapacity}");

        if (gHandler.CurrentGarage().AvailableSlots < gHandler.CurrentGarage().MaxCapacity)
        {
            Console.WriteLine("Garage is not empty! Cannot populate non-empty garage.");
            return;
        }

        Console.WriteLine(OPTION_QUIT);

        try{
            Console.WriteLine("Please enter the number of vehicles you want created.");
            int userSelection = SelectionHandler.UserInputSelection(1, gHandler.CurrentGarage().MaxCapacity);

            Random random = new();
            int cap = Math.Min(userSelection, (int)gHandler.CurrentGarage().AvailableSlots);
            int vehiclesAdded = 0;
            while(cap > 0)
            {
                int maxSize = Math.Min(Enum.GetNames<VehicleType>().Length-1, (int)gHandler.CurrentGarage().AvailableSlots);
                gHandler.CurrentGarage().ParkVehicle(VehicleCreator.CreateVehicle(random, maxSize));
                cap = Math.Min(userSelection-(++vehiclesAdded), (int)gHandler.CurrentGarage().AvailableSlots);
            }
            if(vehiclesAdded < userSelection)
            {
                Console.WriteLine("Garage full, cap was enforced.");
            }
            Console.WriteLine($"Success! Garage is populated with {vehiclesAdded} vehicles.");
            return;
        }
        catch (UserTerminationException)
        {
            throw;
        }
        catch (UserBackNavigationException)
        {
            Console.WriteLine("No vehicles created.");
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! "+e.Message);
            return;
        }
    }
    
}