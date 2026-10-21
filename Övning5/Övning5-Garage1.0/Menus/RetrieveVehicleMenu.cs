using System.Text.RegularExpressions;
using Övning5_Garage1._0.Exceptions;
using Övning5_Garage1._0.Models;

namespace Övning5_Garage1._0.Menus;

public class RetrieveVehicleMenu
{

    const string STAR_SEPARATOR = "***************************************";
    const string MENU_TITLE = "**********  RETRIEVAL MENU   **********";
    const string LINE_SEPARATOR = "______________________________________";
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
        while (true)
        {
            Console.WriteLine(LINE_SEPARATOR); 
            string userInput = UserInputRegistreringsnummer();
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException();
            }
            if (UserBackNavigationSignal(userInput))
            {
                return;
            }

            try{
                if(!ValidRegistreringsnummer(userInput))
                {
                    Console.WriteLine($"{userInput} is not a valid registreringsnummer.");
                }
                else
                {
                    Vehicle vehicle = garage.RetrieveVehicle(userInput);
                    Console.WriteLine($"Success! The following vehicle was retrieved:");
                    Console.WriteLine(vehicle.ListVehicleAttributes());
                    return;
                }
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


    private static string UserInputRegistreringsnummer()
    {
        Console.WriteLine("Please enter the registreringsnummer of the vehicle.");
        Console.WriteLine("Press \'q\' to quit or \'b\' to go back.");
        Console.Write("> ");
        return Console.ReadLine();
    }
    
    private static bool ValidRegistreringsnummer(string input){

        string reg = input ?? "error";
        reg = Regex.Replace(reg, @"\s", "");
                  
        if(reg.Length != 6)
        {
            return false;
        }

        if (!char.IsDigit(reg.ElementAt(3)) || !char.IsDigit(reg.ElementAt(4)))
        {
            return false;
        }

        return true;
    }

    private static bool UserBackNavigationSignal(string str)
    {
        if(str == "b")
        {
            return true;
        }
        return false;
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