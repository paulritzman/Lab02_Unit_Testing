using System;
using ATM;
using Xunit;

namespace ATMTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void MenuInputValidation_Any(string menuInput)
        {
            Assert.True(Program.ValidateMenuInput(menuInput));
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("0")]
        [InlineData("4.2")]
        [InlineData("blue")]
        public void MenuInputValidation_False(string menuInput)
        {
            Assert.False(Program.ValidateMenuInput(menuInput));
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