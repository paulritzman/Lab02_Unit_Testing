using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Program
    {
        public static double balance = 5000.00;

        public static void Main(string[] args)
        {
            PrintATMGreeting();

            string menuSelection = ValidateMenuPrompt();

            switch (menuSelection)
            {
                case "1":
                    ViewBalance();
                    break;
                case "2":
                    PrintWithdrawalMenu();
                    string withdrawalInput = Console.ReadLine();
                    break;
            }

            Console.ReadLine();
        }

        public static void PrintATMGreeting()
        {
            Console.WriteLine(
                "\t\tThank you for using the CF401 ATM!\n" +
                "\tPlease use the menu below to manage your account.\n");
        }

        public static void PrintMenuOptions()
        {
            Console.WriteLine(
                "1) View your current bank account balance.\n" +
                "2) Make a withdrawl from your account.\n" +
                "3) Make a deposit into your account.\n" +
                "4) Exit out of the ATM.\n");
        }

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

        public static void ViewBalance()
        {
            Console.WriteLine($"Your current balance is {balance.ToString("C")}.\n");
        }

        public static void PrintWithdrawalMenu()
        {
            Console.Clear();
            Console.Write(
                "How much money would you like to withdrawal?\n" +
                "(Please enter a positive number, other input will take you back to the main menu.)\n\n" +
                "Enter withdrawal amount here: ");
        }

        public static bool ValidateWithdrawalInput(string withdrawalInput)
        {
            double validAmount = 0;
            try
            {
                validAmount = double.Parse(withdrawalInput);

                if (validAmount > 0.01)
                {
                    Console.Clear();
                    return true;
                }
                else
                {
                    Console.WriteLine("\nSorry, you can't withdraw less than 1 penny.\n");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nSorry, we're unable to process your transaction. {e.Message}\n");
                return false;
            }
        }

        public static double MakeWithdrawal(double requestAmount)
        {
            balance = balance - requestAmount;
            return balance;
        }

        public static double MakeDeposit(double insertAmount)
        {
            balance = balance + insertAmount;
            return balance;
        }
    }
}