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

        public void RunMainMenu()
        {
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
                    // Do display catering items
                }
                else if (userInput.Equals("2"))
                {
                    Console.WriteLine("You selected 2.  Select Product: ");
                    // Do Order
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
    }
}
