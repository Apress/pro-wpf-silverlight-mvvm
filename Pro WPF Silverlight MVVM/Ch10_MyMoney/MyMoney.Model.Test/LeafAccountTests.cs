using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyMoney.Model.Test
{
    [TestClass]
    public class LeafAccountTests
    {
        [TestMethod]
        public void TestDefaultAccountBalanceIsZero()
        {
            LeafAccount account = new LeafAccount("AC1");

            Assert.AreEqual(account.Balance, Money.Zero);
        }

        [TestMethod]
        public void TestAccountBalanceAllDeposits()
        {
            LeafAccount account = new LeafAccount("AC1");
            
            account.AddEntry(new Entry(EntryType.Deposit, 15.05M));
            account.AddEntry(new Entry(EntryType.Deposit, 67.32M));
            account.AddEntry(new Entry(EntryType.Deposit, 11.10M));
            account.AddEntry(new Entry(EntryType.Deposit, 112.35M));

            Assert.AreEqual(account.Entries.Count(), 4);
            Assert.AreEqual(account.Balance, 205.82M);
        }
    }
}
