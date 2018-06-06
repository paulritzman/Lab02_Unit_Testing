using System;
using ATM;
using Xunit;

namespace ATMTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanReturnBalance_5000()
        {
            Assert.Equal(5000, Program.ViewBalance());
        }
    }
}
