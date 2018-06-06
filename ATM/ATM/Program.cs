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
            PrintMenuOptions();

            uint userSelection = 0;
            try
            {
                userSelection = UInt32.Parse(Console.ReadLine());
                if (userSelection == 0 || userSelection > 4)
                {
                    Console.WriteLine("Please enter 1, 2, 3, or 4.");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Please input one of the specified options.\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: The input type didn't match one of the specified options.\n");
            }



            if (userSelection == 2)
            {
                Console.Write("Enter the amount you would like to withdraw: ");

                double requestAmount = 0.00;
                try
                {
                    requestAmount = double.Parse(Console.ReadLine());
                }
                catch
                {

                }
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

        public static void ViewBalance()
        {
            Console.WriteLine($"Your current balance is {balance.ToString("C")}.\n");
        }

        public static double MakeWithdrawal(double requestAmount)
        {
            // try/catch for negative balance, throw exception
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