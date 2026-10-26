
using Övning6_Garage2._0.Menus;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Services;

namespace Övning6.Garage2._0;

public class Program
{
    public static void Main()
    {
        List<Garage> garages = [new ("Default Garage",20)];
        int currentGarageIndex = 0;

        Console.WriteLine("\nWelcome to Övning 6.0!");
        while(true){

            try{
                MainMenu.StartMainMenu(garages, ref currentGarageIndex);
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