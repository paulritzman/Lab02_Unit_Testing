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
            double currentBal = ViewBalance();
            Console.WriteLine(currentBal.ToString("C"));
            Console.ReadLine();
        }

        public static double ViewBalance()
        {
            return balance;
        }
    }
}
