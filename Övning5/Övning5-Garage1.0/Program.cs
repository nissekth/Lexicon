
using Övning5_Garage1._0.Exceptions;
using Övning5_Garage1._0.Models;
using Övning5_Garage1._0.Menus;

namespace Övning5_Garage1._0;

public class Program
{
    public static void Main()
    {
        Garage[] garages = [new ("Default Garage",20)];
        int currentGarageIndex = 0;

        Console.WriteLine("\nWelcome to Övning 5.0!");
        while(true){

            try{
                EnterWelcomeMenu(ref garages, ref currentGarageIndex);
            }
            catch(UserTerminationException e)
            {
                Console.WriteLine(e.Message);
                break;
            }

        }

        Console.WriteLine("Shutting off. Goodbye!");
    }



    //Remove parameter when implementing more garages
    public static void EnterWelcomeMenu(ref Garage[] garages, ref int currentGarageIndex)
    {

        int userSelection = 0;
        while (true)
        {    
            MainMenu.StartMainMenu();
            string? userInput = MainMenu.GetUserSelection();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine($"You must select one of the options!");
                continue;
            }
            //Bad practice but can be fixed later, propagating a termination signal w/o exception
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }

            bool parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 6)
                {
                    Console.WriteLine($"Invalid option! The number must be between 1 and 6!\n");
                    userSelection = 0;
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and 6!\n");
            }
        }

        try
        {
            if(userSelection == 1)
            {
                ParkVehicleMenu.StartParkingMenu(garages[currentGarageIndex]);
            }
            else if (userSelection == 2)
            {
                RetrieveVehicleMenu.StartRetrievalMenu(garages[currentGarageIndex]);
            }
            else if (userSelection == 3)
            {
                VehicleInformationMenu.StartInformationMenu(garages[currentGarageIndex]);
                
            }
            else if(userSelection == 4)
            {
                Garage garage = CreateGarageMenu.CreateNewGarage();
                Array.Resize(ref garages, garages.Length + 1);
                garages[garages.Length - 1] = garage;
                currentGarageIndex = garages.Length - 1;
            }
            else if(userSelection == 5)
            {
                int? index = SwitchGarageMenu.SwitchCurrentGarage(garages);
                if(index != null){
                    currentGarageIndex = (int)index;
                }
            }            
            else if(userSelection == 6)
            {
                PopulationMenu.PopulateGarage(garages[currentGarageIndex]);
            }
        }
        catch(UserTerminationException)
        {
            throw new UserTerminationException();
        }
        catch(Exception e)
        {
            Console.WriteLine("Error! " + e.Message);
        }

    }

    private static bool UserQuitSignal(string str)
    {
        if(str == "q")
        {
            return true;
        }
        return false;
    }

}