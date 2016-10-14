using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyMoney.Model.Test
{
    [TestClass]
    public class EntryTests
    {
        [TestMethod]
        public void TestCalculateNewBalanceWithDeposit()
        {
            Entry entry = new Entry(EntryType.Deposit, 10M);

            Money oldBalance = 5M;
            Money newBalance = entry.CalculateNewBalance(oldBalance);

            Assert.IsTrue(newBalance > oldBalance);
            Assert.AreEqual(newBalance, new Money(15M));
        }

        [TestMethod]
        public void TestCalculateNewBalanceWithWithdrawal()
        {
            Entry entry = new Entry(EntryType.Withdrawal, 5M);

            Money oldBalance = 10M;
            Money newBalance = entry.CalculateNewBalance(oldBalance);

            Assert.IsTrue(newBalance < oldBalance);
            Assert.AreEqual(newBalance, new Money(5m));
        }
    }
}
