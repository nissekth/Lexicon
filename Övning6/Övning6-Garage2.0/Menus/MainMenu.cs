using Övning6_Garage2._0.Exceptions;
using Övning6_Garage2._0.Models;
using Övning6_Garage2._0.Services;

namespace Övning6_Garage2._0.Menus;

public class MainMenu
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
    public static void StartMainMenu(List<Garage> garages, ref int currentGarageIndex)
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
                int userSelection = SelectionService.UserInputSelection(1, NUMBER_OF_OPTIONS);
                
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
                    garages.Add(garage);
                    currentGarageIndex = garages.Count - 1;
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