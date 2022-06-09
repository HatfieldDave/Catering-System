using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Money
    {
        public decimal Balance { get; private set; } = 0;

        /// <summary>
        /// Adds the desired amount to the users balance but won't go above $1000
        /// </summary>
        /// <param name="amount">Amount to be added</param>
        public string AddMoney(int amount)
        {
            if (amount >= 1)
            {
                Balance += amount;
                if (Balance > 1000)
                {
                    Balance = 1000;
                    return "Too much entered.  Balance set to 1000";
                }
                return "Balance updated, your new balance is " + Balance;
            }
            return "Can not enter a value less than one";
        }

        /// <summary>
        /// Attempts to remove the desired amount of money from balance.  Returns false if the amount is over the current balance, otherwise returns true
        /// </summary>
        /// <param name="amount">Amount to be removed</param>
        /// <returns>Whether the operation was succesful</returns>
        public bool RemoveMoney(decimal amount)
        {


            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GiveChange()
        {


            return "";
        }

        private int MakeChange(decimal moneyDenomination)
        {


            return 1; // Stop yelling at me case.
        }
    }
}
