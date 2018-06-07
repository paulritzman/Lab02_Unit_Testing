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
        [InlineData("1")]
        [InlineData("1000")]
        [InlineData("10.01")]
        [InlineData("19.99")]
        public void ValidateWithDrawalInput_True(string request)
        {
            Assert.True(Program.ValidateWithdrawalInput(request));
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-1000")]
        [InlineData("0.01")]
        [InlineData("abcd")]
        public void ValidateWithDrawalInput_False(string request)
        {
            Assert.False(Program.ValidateWithdrawalInput(request));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1000")]
        [InlineData("10.01")]
        [InlineData("19.99")]
        public void ValidateDepositInput_True(string request)
        {
            Assert.True(Program.ValidateDepositInput(request));
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-1000")]
        [InlineData("0.01")]
        [InlineData("abcd")]
        public void ValidateDepositInput_False(string request)
        {
            Assert.False(Program.ValidateDepositInput(request));
        }

        [Theory]
        [InlineData(1000, 4000)]
        [InlineData(1234, 3766)]
        [InlineData(4444.45, 555.55)]
        [InlineData(1999.50, 3000.50)]
        public void CanWithdrawAny_True(double balanceAfter, double request)
        {
            Program.balance = 5000.00;
            Assert.Equal(balanceAfter, Program.MakeWithdrawal(request));
        }

        [Theory]
        [InlineData(6000, 1000)]
        [InlineData(6234, 1234)]
        [InlineData(5555.55, 555.55)]
        [InlineData(10000.01, 5000.01)]
        public void CanDepositAny_True(double balanceAfter, double request)
        {
            Program.balance = 5000.00;
            Assert.Equal(balanceAfter, Program.MakeDeposit(request));
        }
    }
}