using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Program
    {
        // Starts the user off with 5000 in their bank account
        public static double balance = 5000.00;

        public static void Main(string[] args)
        {
            // Print greeting to user
            PrintATMGreeting();

            string menuSelection = "";

            // Loop through application until user hits the "4" key to exit the program
            do
            {
                // Loop through menu prompt, presenting user with ATM options
                // Loops until user types 1, 2, 3, or 4
                menuSelection = ValidateMenuPrompt();

                // Initiate functions to perform user's desired action, based on menuSelection input
                switch (menuSelection)
                {
                    // Allows user to see their bank balance
                    case "1":
                        ViewBalance();
                        break;
                    // Allows user to withdraw money from their account
                    case "2":
                        double requestedWithdrawal = ValidateWithdrawalPrompt();
                        if (requestedWithdrawal >= 1)
                        {
                            MakeWithdrawal(requestedWithdrawal);
                        }
                        break;
                    // Allows the user to deposit money into their account
                    case "3":
                        double requestedDeposit = ValidateDepositPrompt();
                        if (requestedDeposit >= 1)
                        {
                            MakeDeposit(requestedDeposit);
                        }
                        break;
                    // Exits from the application
                    case "4":
                        Environment.Exit(0);
                        break;
                }
            } while (menuSelection != "4");
        }

        /// <summary>
        /// Method used to print a greeting to the user when initially executing the application.
        /// </summary>
        public static void PrintATMGreeting()
        {
            Console.WriteLine(
                "\t\tThank you for using the CF401 ATM!\n" +
                "\tPlease use the menu below to manage your account.\n");
        }

        /// <summary>
        /// Method used to print the main ATM menu options for the user to interact with the ATM.
        /// </summary>
        public static void PrintMenuOptions()
        {
            Console.WriteLine(
                "1) View your current bank account balance.\n" +
                "2) Make a withdrawl from your account.\n" +
                "3) Make a deposit into your account.\n" +
                "4) Exit out of the ATM.\n");
        }

        /// <summary>
        /// Helper method which contains a loop - calling PrintMenuOptions() and ValidateMenuInput()
        /// until the user types a valid menu option.
        /// Returns menu option selected of type: string.
        /// </summary>
        /// <returns>String: Menu option selected.</returns>
        public static string ValidateMenuPrompt()
        {
            string menuSelection = "";
            bool menuInputValid = false;
            while (menuInputValid == false)
            {
                PrintMenuOptions();

                menuSelection = Console.ReadLine();
                menuInputValid = ValidateMenuInput(menuSelection);
            }

            return menuSelection;
        }

        /// <summary>
        /// Method used to determine if the user input obtained from the main ATM menu matches any menu option.
        /// </summary>
        /// <param name="menuInput"></param>
        /// <returns>Boolean: True/False depending on if user input matched a valid menu option.</returns>
        public static bool ValidateMenuInput(string menuInput)
        {
            uint validSelection = 0;
            try
            {
                validSelection = UInt32.Parse(menuInput);

                if (validSelection >= 1 && validSelection <= 4)
                {
                    Console.Clear();
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, that wasn't one of the menu options. " +
                        "Please type a number between 1 and 4.\n");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Sorry, that wasn't one of the menu options. {e.Message}\n");
                return false;
            }
        }

        /// <summary>
        /// Method used to print the user's current balance to the screen.
        /// </summary>
        public static void ViewBalance()
        {
            Console.WriteLine($"Your current balance is {balance.ToString("C")}.\n");
        }

        /// <summary>
        /// Method used to print the ATM Withdrawal menu options for the user to interact with the Withdrawal feature.
        /// </summary>
        public static void PrintWithdrawalMenu()
        {
            Console.Clear();
            Console.Write(
                "How much money would you like to withdrawal?\n" +
                "(Please enter a positive number, other input will take you back to the main menu.)\n\n" +
                "Enter withdrawal amount here: ");
        }

        /// <summary>
        /// Helper method which calls PrintWithdrawalMenu() and ValidateWithdrawalInput().
        /// Returns amount the user wants to withdraw of type: double.
        /// </summary>
        /// <returns>Double: Amount user wants to withdraw from bank account.</returns>
        public static double ValidateWithdrawalPrompt()
        {
            PrintWithdrawalMenu();
            string withdrawalSelection = Console.ReadLine();

            if (ValidateWithdrawalInput(withdrawalSelection))
            {
                return double.Parse(withdrawalSelection);
            }

            return 0;
        }
        
        /// <summary>
        /// Method used to determine if the user input obtained from ATM Withdrawal menu can be converted to type: double.
        /// Minimum withdrawal amount: 1.00
        /// </summary>
        /// <param name="withdrawalInput"></param>
        /// <returns>Boolean: True/False depending on if user input conforms to allowed format and minimum withdrawal amount.</returns>
        public static bool ValidateWithdrawalInput(string withdrawalInput)
        {
            double validAmount = 0;
            try
            {
                validAmount = double.Parse(withdrawalInput);

                if (validAmount >= 1)
                {
                    Console.Clear();
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, you can't withdraw less than 1 dollar.\n");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Sorry, we're unable to process your transaction. {e.Message}\n");
                return false;
            }
        }

        /// <summary>
        /// Method used to conduct the withdrawal from the user's bank account.
        /// </summary>
        /// <param name="requestAmount"></param>
        /// <returns>Double: Bank account balance after withdraw request performed.</returns>
        public static double MakeWithdrawal(double requestAmount)
        {
            if ((balance - requestAmount) >= 0)
            {
                Console.WriteLine("Withdrawal Successful!\n");
                balance = balance - requestAmount;
            }
            else
            {
                Console.WriteLine("Unable to process transaction: Insufficient Funds.\n");
            }
            return balance;
        }

        /// <summary>
        /// Method used to print the ATM Deposit menu options for the user to interact with the Deposit feature.
        /// </summary>
        public static void PrintDepositMenu()
        {
            Console.Clear();
            Console.Write(
                "How much money would you like to deposit?\n" +
                "(Please enter a positive number, other input will take you back to the main menu.)\n\n" +
                "Enter deposit amount here: ");
        }

        /// <summary>
        /// Helper method which calls PrintDepositMenu() and ValidateDepsitInput().
        /// Returns amount the user wants to deposit of type: double.
        /// </summary>
        /// <returns>Double: Amount user wants to deposit into bank account.</returns>
        public static double ValidateDepositPrompt()
        {
            PrintDepositMenu();
            string depositSelection = Console.ReadLine();

            if (ValidateDepositInput(depositSelection))
            {
                return double.Parse(depositSelection);
            }

            return 0;
        }

        /// <summary>
        /// Method used to determine if the user input obtained from ATM Deposit menu can be converted to type: double.
        /// Minimum deposit amount: 1.00
        /// </summary>
        /// <param name="depositInput"></param>
        /// <returns>Boolean: True/False depending on if user input conforms to allowed format and minimum deposit amount.</returns>
        public static bool ValidateDepositInput(string depositInput)
        {
            double validAmount = 0;
            try
            {
                validAmount = double.Parse(depositInput);

                if (validAmount >= 1)
                {
                    Console.Clear();
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, you must deposit at least 1 dollar.\n");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Sorry, we're unable to process your transaction. {e.Message}\n");
                return false;
            }
        }

        /// <summary>
        /// Method used to conduct the deposit into the user's bank account.
        /// </summary>
        /// <param name="insertAmount"></param>
        /// <returns>Double: Bank account balance after deposit request performed.</returns>
        public static double MakeDeposit(double insertAmount)
        {
            Console.WriteLine("Deposit Successful!\n");
            balance = balance + insertAmount;
            return balance;
        }
    }
}