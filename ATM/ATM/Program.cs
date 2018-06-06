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
            Console.WriteLine("\t\tThank you for using the CF401 ATM!\n" +
                "\tPlease use the menu below to manage your account.\n");

            PrintMenuOptions();

            MakeWithdrawl(4000);
            ViewBalance();

            MakeDeposit(300);
            ViewBalance();

            Console.ReadLine();
        }

        private static void PrintMenuOptions()
        {
            Console.WriteLine("1) View your current bank account balance.\n" +
                "2) Make a withdrawl from your account.\n" +
                "3) Make a deposit into your account.\n" +
                "4) Exit the ATM.");
        }

        private static void ViewBalance()
        {
            Console.WriteLine($"Your current balance is {balance.ToString("C")}.\n");
        }

        public static double MakeWithdrawl(double requestAmount)
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