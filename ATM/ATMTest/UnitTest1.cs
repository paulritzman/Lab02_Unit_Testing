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
            Program.balance = 5000.00;
            Assert.Equal(4999, Program.MakeWithdrawal(1));
        }

        [Theory]
        [InlineData(1000, 4000)]
        [InlineData(1234, 3766)]
        [InlineData(3500, 1500)]
        public void CanWithdrawAny(double balanceAfter, double request)
        {
            Program.balance = 5000.00;
            Assert.Equal(balanceAfter, Program.MakeWithdrawal(request));
        }
    }
}