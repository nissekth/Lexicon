using Övning9_Garage3._0.Exceptions;
using Övning9_Garage3._0.Handlers;

namespace Övning9_Garage3._0.Menus;

public class MainMenu : IMenu
{
    const string SEPARATOR = "**************************************";
    const string MENU_TITLE = "***********   MAIN  MENU   ***********";
    const string OPTION_1 = "1: Park vehicle.";
    const string OPTION_2 = "2: Retrieve vehicle.";
    const string OPTION_3 = "3: List vehicles.";
    const string OPTION_4 = "4: Create garage.";
    const string OPTION_5 = "5: Switch garage.";
    const string OPTION_6 = "6: Populate garage with random vehicles.";
    const string OPTION_QUIT = "Press \'q\' to quit.";
    const int NUMBER_OF_OPTIONS = 6;
    public static void StartMenu(GarageHandler gHandler)
    {
        while(true){
            Console.WriteLine("\n\n"+SEPARATOR);
            Console.WriteLine(MENU_TITLE);
            Console.WriteLine(SEPARATOR);
            
            Console.WriteLine("Please select what you wish to do by entering a number below corresponding to your wish.");
            Console.WriteLine(OPTION_1);
            Console.WriteLine(OPTION_2);
            Console.WriteLine(OPTION_3);
            Console.WriteLine(OPTION_4);
            Console.WriteLine(OPTION_5);
            Console.WriteLine(OPTION_6);
            Console.WriteLine(OPTION_QUIT);

            try
            {
                int userSelection = SelectionHandler.UserInputSelection(1, NUMBER_OF_OPTIONS);
                
                if(userSelection == 1)
                {
                    ParkVehicleMenu.StartMenu(gHandler);
                }
                else if (userSelection == 2)
                {
                    RetrieveVehicleMenu.StartMenu(gHandler);
                }
                else if (userSelection == 3)
                {
                    VehicleInformationMenu.StartMenu(gHandler);
                    
                }
                else if(userSelection == 4)
                {
                   CreateGarageMenu.StartMenu(gHandler);
                }
                else if(userSelection == 5)
                {
                    SwitchGarageMenu.StartMenu(gHandler);
                }            
                else if(userSelection == 6)
                {
                    PopulationMenu.StartMenu(gHandler);
                }
            }
            catch(UserBackNavigationException)
            {
                continue;
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
    }

}