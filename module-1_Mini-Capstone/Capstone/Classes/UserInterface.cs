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
                    Console.WriteLine("");
                    // Do display catering items
                    DisplayItems();
                    Console.WriteLine("You selected 2.  Place your order.");
                    Console.WriteLine("");

                }
                else if (userInput.Equals("2"))
                {
                    RunOrderMenu();
                    // Do Order
                }
                else if (userInput.Equals("3"))
                {
                    Console.WriteLine("You selected 3.  Exiting program.");
                    Console.WriteLine("");
                    done = true; // Exits the program
                    cateringFile.WriteLog();
                }
                else
                {
                    Console.WriteLine("User input not valid.  Choose again.");
                }
            }
        }

        /// <summary>
        /// Contains all the logic necessary for the order menu
        /// </summary>
        public void RunOrderMenu()
        {
            String userInput;

            bool done = false;

            while (!done)
            {
                try
                {
                    Console.WriteLine("You selected 2.  Place your order.");
                    Console.WriteLine("");

                    Console.WriteLine("(1) Add Money.");
                    Console.WriteLine("(2) Select Products");
                    Console.WriteLine("(3) Complete Transaction");

                    Console.WriteLine("Current Account Balance: " + catering.Balance.ToString("c"));
                    userInput = Console.ReadLine();

                    if (userInput.Equals("1"))
                    {
                        Console.WriteLine("You selected 1. Enter Amount: ");
                        Console.WriteLine("");
                        string moneyToAdd = Console.ReadLine();
                        int amount = int.Parse(moneyToAdd);

                        if (amount < 1)  // If amount is less than 1 can not enter less than one
                        {
                            Console.WriteLine("Can not enter a value less than one");
                        }
                        else if (amount + catering.Balance > 1000) // Balnce can't be over 1000
                        {
                            catering.Balance = 1000;
                            cateringFile.Log("ADD MONEY", 1000 - catering.Balance, catering.Balance); // 1000 minus the catering balance is the actual amount the balance changed in this case
                            Console.WriteLine("Too much entered.  Balance set to 1000");
                        }
                        else // If everythings good add amount
                        {
                            catering.AddMoney(amount);
                            cateringFile.Log("ADD MONEY", amount, catering.Balance);
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
                        Console.WriteLine("");
                        // Return change
                        CompleteOrder();
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("User input not valid.  Choose again.");
                    }
                } 
                catch (FormatException ex)
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

            Console.Write("You selected 2.  Enter Item Code: ");
            Console.WriteLine("");// Takes user input for the item code
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
            Console.WriteLine("");
            string amountString = Console.ReadLine();
            int amount = int.Parse(amountString);

            if(amount <= 0)
            {
                Console.WriteLine("You must enter a whole number larger than 0");
                return;
            }


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

            CateringItem purchasedItem = catering.DoOrder(itemCode, amount); // Once all the checks are complete changes the number of quantity of the related CateringItem as well as the apprpriate amount of money
            decimal totalAmount = purchasedItem.ItemCost * purchasedItem.ItemQuantity;
            string logString = purchasedItem.ItemQuantity + " " + purchasedItem.ItemName + " " + purchasedItem.ItemCode;
            cateringFile.Log(logString, totalAmount, catering.Balance);
        }

        /// <summary>
        /// Displays the customers order to the screen and prepares the CateringSystem for the next customer
        /// </summary>
        public void CompleteOrder()
        {
            List <CateringItem> receipt = catering.GiveReceipt();
            decimal remainingBalance = catering.Balance;  // Stores balance for use in logging

            foreach (CateringItem item in receipt)
            {
                decimal itemTotal = item.ItemCost * item.ItemQuantity; // Total cost of this item

                // Do a bunch of stuff to make it look good
                string itemCostPadded = item.ItemCost.ToString("c").PadRight(6);
                string itemTotalPadded = itemTotal.ToString("c").PadRight(4);
                string itemTypePadded = "";
                string itemNamePadded = item.ItemName.PadRight(25);
                string itemQuantityPadded = item.ItemQuantity.ToString().PadRight(2);

                

                // Determining the amount of each denomination of money that the user receives in change
                int twenties = catering.ChangeGetter(20.00m);
                int tens = catering.ChangeGetter(10.00m);
                int fives = catering.ChangeGetter(5.00m);
                int ones = catering.ChangeGetter(1.00m);
                int quarters = catering.ChangeGetter(.25m);
                int dimes = catering.ChangeGetter(.10m);
                int nickels = catering.ChangeGetter(.05m);

                Console.WriteLine("Your change is: ");
                Console.WriteLine(twenties + " Twenties");
                Console.WriteLine(tens + " Tens");
                Console.WriteLine(fives + " Fives");
                Console.WriteLine(ones + " ones");
                Console.WriteLine(quarters + " quarters");
                Console.WriteLine(dimes + " dimes");
                Console.WriteLine("and " + nickels +" nickels.");
                Console.WriteLine("");

                // Determine longform ItemType name
                if (item.ItemType.Equals("A"))
                {
                    itemTypePadded = "Appetizer";
                    itemTypePadded = itemTypePadded.PadRight(10);
                }
                if (item.ItemType.Equals("B"))
                {
                    itemTypePadded = "Beverage";
                    itemTypePadded = itemTypePadded.PadRight(10);
                }
                if (item.ItemType.Equals("D"))
                {
                    itemTypePadded = "Dessert";
                    itemTypePadded = itemTypePadded.PadRight(10);
                }
                if (item.ItemType.Equals("E"))
                {
                    itemTypePadded = "Entree";
                    itemTypePadded = itemTypePadded.PadRight(10);
                }

                // Create string for printing
                string lineString = $"{itemQuantityPadded} {itemTypePadded} {itemNamePadded} {itemCostPadded} {itemTotalPadded} ";

                Console.WriteLine(lineString);
            }

            Console.WriteLine("");
            Console.WriteLine("Total: " + catering.Total.ToString("c"));

            cateringFile.Log("GIVE CHANGE:", remainingBalance, catering.Balance);

            catering.ClearCartAndBalance();
        }
    }
}
