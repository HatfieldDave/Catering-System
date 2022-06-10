using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    public class UserInterface
    {
        private CateringSystem catering = new CateringSystem();
        private FileAccess cateringFile = new FileAccess();
        public void RunMainMenu()
        {


            cateringFile.ReadFromFile(catering);
            //catering.TestMethod();

            bool done = false;

            while (!done)
            {
                String userInput;  // Stores user input
                // TODO Make pretty?
                Console.WriteLine("(1) Display Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");
                userInput = Console.ReadLine();

                if (userInput.Equals("1"))
                {
                    Console.WriteLine("You selected 1 to display items.");
                    // Do display catering items
                    DisplayItems();

                }
                else if (userInput.Equals("2"))
                {
                    Console.WriteLine("You selected 2.  Place your order.");
                    RunOrderMenu();
                    // Do Order
                }
                else if (userInput.Equals("3"))
                {
                    Console.WriteLine("You selected 3.  Exiting program.");
                    done = true; // Exits the program
                }
                else
                {
                    Console.WriteLine("User input not valid.  Choose again.");
                }
            }
        }
        public void RunOrderMenu()
        {
            String userInput;

            bool done = false;

            while (!done)
            {
                Console.WriteLine("(1) Add Money.");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                Console.WriteLine("Current Account Balance: " + "");
                userInput = Console.ReadLine();

                if (userInput.Equals("1"))
                {
                    Console.WriteLine("You selected 1. Enter Amount: ");
                    string moneyToAdd = Console.ReadLine();
                    int amount = int.Parse(moneyToAdd);

                    if (amount < 1)  // If amount is less than 1 can not enter less than one
                    {
                        Console.WriteLine("Can not enter a value less than one");
                    }
                    else if (amount + catering.Balance > 1000) // Balnce can't be over 1000
                    {
                        catering.Balance = 1000;
                        Console.WriteLine("Too much entered.  Balance set to 1000");
                    }
                    else // If everythings good add amount
                    {
                        catering.AddMoney(amount);
                        Console.WriteLine("Balance updated, new balance is: " + catering.Balance);
                    }
                }
                else if (userInput.Equals("2"))
                {
                    Console.WriteLine("You selected 2.  Select Product: ");


                }
                else if (userInput.Equals("3"))
                {
                    Console.WriteLine("You selected 3.  Checking out and returning to main menu");
                    // Return change
                    done = true; // Exits the program
                }
                else
                {
                    Console.WriteLine("User input not valid.  Choose again.");
                }
            }
        }
        public void DisplayItems()
        {
            string[] displayLines = catering.GetStringArray();
            foreach (string line in displayLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
