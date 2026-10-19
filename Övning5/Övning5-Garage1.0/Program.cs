using Övning5_Garage1._0.Views;

namespace Övning5_Garage1._0;

public class Program
{
    public static void Main()
    {

        Console.WriteLine("Welcome to Garage 1.0!\nPlease select what you wish to do by entering a number below corresponding to your wish.");
        EnterWelcomeMenu();





    }

    public static int EnterWelcomeMenu()
    {
        int userSelection = 0;
        while (userSelection == 0)
        {    
            MainView.StartMainView();
            Boolean parseSuccess = int.TryParse(MainView.GetUserSelection(),out userSelection);
            if (parseSuccess)
            {
                if(userSelection < 1 || userSelection > 3)
                {
                    Console.WriteLine($"Invalid option! Please provide an integer between 1 and 3!\n");
                    userSelection = 0;
                }
            }
            else
            {
                Console.WriteLine($"Invalid option! Please provide an integer between 1 and 3!\n");
            }
        }
        return userSelection;
    }


}