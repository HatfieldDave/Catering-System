using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

                Console.WriteLine("Current Account Balance: " + catering.Balance);
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
                    MakePurchase();
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

        public void MakePurchase()
        {
            if (catering.Balance == 0) // Can't place an order if you don't have a balance
            {
                Console.WriteLine("You must have a balance.");
                return;
            }

            Console.Write("You selected 2.  Enter Item Code: "); // Takes user input for the item code
            string itemCode = Console.ReadLine().ToUpper();


            if (!catering.ContainsItem(itemCode)) // Checks that the item code is valid
            {
                Console.WriteLine("Invalid selection.  Choose another item");
                return;
            }

            if (!catering.InStock(itemCode)) // Checks that the indicated item is in stock
            {
                Console.WriteLine("Item is out of stock.");
                return;
            }

            Console.Write("Select amount: ");  // Takes user input for the desired amount of the item
            string amountString = Console.ReadLine();
            int amount = int.Parse(amountString);


            if (!catering.SufficientStock(itemCode, amount))  // Checks to make sure that there is enough of the item avaible
            {
                Console.WriteLine("Not enough Available.");
                return;
            }

            if (!catering.SufficientFunds(itemCode, amount)) // Checks to make sure the user has enough money
            {
                Console.WriteLine("Insufficient Funds");
                return;
            }

            catering.DoOrder(itemCode, amount);

        }
    }
}
