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

            string menuSelection = "";
            bool menuInputValid = false;
            while (menuInputValid == false)
            {
                PrintMenuOptions();

                menuSelection = Console.ReadLine();
                menuInputValid = ValidateMenuInput(menuSelection);
            }

            Console.WriteLine("Thanks!");

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
                    Console.WriteLine("\nSorry, that wasn't one of the menu options. " +
                        "Please type a number between 1 and 4.\n");

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nSorry, that wasn't one of the menu options. {e.Message}\n");

                return false;
            }
        }

        public static void ViewBalance()
        {
            Console.WriteLine($"Your current balance is {balance.ToString("C")}.\n");
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