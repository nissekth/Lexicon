using Övning5_Garage1._0.Enums;
using Övning5_Garage1._0.Exceptions;
using Övning5_Garage1._0.Models;
using Övning5_Garage1._0.Menus;

namespace Övning5_Garage1._0;

public class Program
{
    public static void Main()
    {

        Garage defaultGarage = new("firstGarage",10);

        Console.WriteLine("Welcome to ÖvningGarage 1.0!");
        while(true){

            try{
                EnterWelcomeMenu(defaultGarage);
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
    public static void EnterWelcomeMenu(Garage firstGarage)
    {
        int userSelection = 0;
        while (true)
        {    
            MainMenu.StartMainMenu();
            string userInput = MainMenu.GetUserSelection();
            //Bad practice but can be fixed later, propagating a termination signal w/o exception
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }

            bool parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 4)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 4!\n");
                    userSelection = 0;
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and 4!\n");
            }
        }

        try
        {
            if(userSelection == 1)
            {
                ParkVehicleMenu.StartParkingMenu(firstGarage);
            }
            else if (userSelection == 2)
            {
                RetrieveVehicleMenu.StartRetrievalMenu(firstGarage);
            }
            else if (userSelection == 3)
            {
                VehicleInformationMenu.StartInformationMenu(firstGarage);
                
            }
            else if(userSelection == 4)
            {
                
            }
        }
        catch(UserTerminationException)
        {
            throw new UserTerminationException();
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