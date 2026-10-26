using Övning6_Garage2._0.Enums;
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Services;

namespace Övning6_Garage2._0.Menus;

public class PopulationMenu
{
    const string SEPARATOR = "***************************************";
    const string MENU_TITLE = "******* INITIAL POPULATION MENU *******";
    const string LINE_SEPARATOR = "_________________________________________";
    const string OPTION_QUIT = "Press \'q\' to quit or \'b\' to go back.\n";
    public static void PopulateGarage(Garage garage)
    {
        Console.WriteLine("\n\n"+SEPARATOR);
        Console.WriteLine(MENU_TITLE);
        Console.WriteLine(SEPARATOR);
        Console.WriteLine(LINE_SEPARATOR);
        Console.WriteLine($"Current garage is: {garage.Name} - Capacity: {garage.MaxCapacity}");

        if (garage.AvailableSlots < garage.MaxCapacity)
        {
            Console.WriteLine("Garage is not empty! Cannot populate non-empty garage.");
            return;
        }

        Console.WriteLine(OPTION_QUIT);

        try{
            Console.WriteLine("Please enter the number of vehicles you want created.");
            int userSelection = SelectionService.UserInputSelection(1, garage.MaxCapacity);

            Random random = new();
            int cap = Math.Min(userSelection, (int)garage.AvailableSlots);
            int vehiclesAdded = 0;
            while(cap > 0)
            {
                int maxSize = Math.Min(Enum.GetNames<VehicleType>().Length-1, (int)garage.AvailableSlots);
                garage.ParkVehicle(VehicleCreator.CreateVehicle(random, maxSize));
                cap = Math.Min(userSelection-(++vehiclesAdded), (int)garage.AvailableSlots);
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