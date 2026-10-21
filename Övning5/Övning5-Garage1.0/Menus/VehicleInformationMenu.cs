using System.Text.RegularExpressions;
using Övning5_Garage1._0.Enums;
using Övning5_Garage1._0.Exceptions;
using Övning5_Garage1._0.Models;

namespace Övning5_Garage1._0.Menus;

public class VehicleInformationMenu
{

    const string STAR_SEPARATOR = "**************************************";
    const string MENU_TITLE = "****** VEHICLE INFORMATION MENU ******";
    const string LINE_SEPARATOR = "______________________________________";
    const string OPTION_1 = "1: List details of a particular vehicle.";
    const string OPTION_2 = "2: List all vehicles; their type and their registreringsnummer.";
    const string OPTION_3 = "3: List type and registreringsnummer of a selection of vehicles.";
    const string OPTION_4 = "4: List the number of parked vehicles of each type the garage allows.";
    const string OPTION_QUIT = "Press \'q\' to quit and \'b\' to go back.";

    public static void StartInformationMenu(Garage garage)
    {


        while(true){
            Console.WriteLine("\n"+STAR_SEPARATOR);
            Console.WriteLine(MENU_TITLE);
            Console.WriteLine(STAR_SEPARATOR);
            Console.WriteLine("Current garage is: " + garage.Name);
            Console.WriteLine(LINE_SEPARATOR);

            Console.WriteLine("Please select what you wish to do by entering a number below corresponding to your wish.");
            Console.WriteLine(OPTION_1);
            Console.WriteLine(OPTION_2);
            Console.WriteLine(OPTION_3);
            Console.WriteLine(OPTION_4);
            Console.WriteLine(OPTION_QUIT);





            
            int userSelection = 0;

            string userInput = GetUserSelection();
            
            if (UserQuitSignal(userInput))
            {
                throw new UserTerminationException("User quit successfully.");
            }
            if (UserBackNavigationSignal(userInput))
            {
                return;
            }

            bool parseSuccess = int.TryParse(userInput,out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 4)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 4!\n");
                    userSelection = 0;
                    continue;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and 4!\n");
            }

            if(userSelection == 1)
            {
                //Determine registreringsnummer
                while (true)
                {
                    Console.WriteLine(LINE_SEPARATOR); 
                    userInput = UserInputRegistreringsnummer();
                    if (UserQuitSignal(userInput))
                    {
                        throw new UserTerminationException();
                    }
                    if (UserBackNavigationSignal(userInput))
                    {
                        break;
                    }

                    try{
                        if(!ValidRegistreringsnummer(userInput))
                        {
                            Console.WriteLine($"{userInput} is not a valid registreringsnummer.");
                        }
                        else
                        {
                            Vehicle vehicle = garage.GetVehicleInformation(userInput);
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
            else if (userSelection == 2)
            {
                //Unneccessary to create this array, perhaps a bit encapsulation breaking?
                //Ishould only request the information I actually need 
                Vehicle[] allParkedVehicles = garage.GetAllVehiclesInformation();
                if(allParkedVehicles.Length < 1)
                {
                    Console.WriteLine("Garage is empty!");
                }
                else
                {
                    foreach(Vehicle v in allParkedVehicles)
                    {
                        Console.WriteLine($"{v.GetType()} {v.Registreringsnummer}");
                    }
                }
            }
            else if (userSelection == 3)
            {
                
                
            }
            else if (userSelection == 4)
            {
                int[] garageStats = garage.GetGarageStats();
                bool empty = true;
                foreach (int vehicleStat in garageStats)
                {
                    if (vehicleStat > 0)
                    {
                        empty = false;
                        break;
                    }
                }
                if(empty)
                {
                    Console.WriteLine("Garage is empty!");
                }
                else
                {
                    int i = 0;
                    foreach(int e in garageStats)
                    {
                        Console.WriteLine($"#{(VehicleType)i++}: {e}");
                    }
                }
            }
        }
    }




    public static string GetUserSelection()
    {
        Console.Write("> ");
        return Console.ReadLine();
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