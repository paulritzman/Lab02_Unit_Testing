using System;
using ATM;
using Xunit;

namespace ATMTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanWithdraw_1()
        {
            Assert.Equal(4999, Program.MakeWithdrawl(1));
        }

        [Theory]
        [InlineData(1000, 4000)]
        public void CanWithdrawAny(double balanceAfter, double request)
        {
            Program.balance = 5000.00;
            Assert.Equal(balanceAfter, Program.MakeWithdrawl(request));
        }
    }
}