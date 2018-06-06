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
            MakeWithdrawl(4000);
            ViewBalance();

            MakeDeposit(300);
            ViewBalance();

            Console.ReadLine();
        }

        public static void ViewBalance()
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
