
using Övning9_Garage3._0.Menus;
using Övning9_Garage3._0.Models;
using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Handlers;

namespace Övning9.Garage3._0;

public class Program
{
    public static void Main()
    {
        GarageHandler garageHandler = new();

        Console.WriteLine("\nWelcome to Övning 9, Garage 3.0!");
        while(true){

            try{
                MainMenu.StartMenu(garageHandler);
            }
            catch(UserTerminationException e)
            {
                Console.WriteLine(e.Message);
                break;
            }

        }

        Console.WriteLine("Shutting off. Goodbye!");
    }


}