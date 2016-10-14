using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyMoney.Model.Test
{
    [TestClass]
    public class CompositeAccountTests
    {
        [TestMethod]
        public void TestAddAccount()
        {
            CompositeAccount ac1 = new CompositeAccount("A");
            CompositeAccount ac2 = new CompositeAccount("B");

            ac1.AddAccount(ac2);

            Assert.AreEqual(1, ac1.ChildAccounts.Count());
            Assert.AreEqual(ac2, ac1.ChildAccounts.FirstOrDefault());
        }

        [TestMethod]
        public void TestRemoveAccount()
        {
            CompositeAccount ac1 = new CompositeAccount("A");
            CompositeAccount ac2 = new CompositeAccount("B");

            ac1.AddAccount(ac2);

            ac1.RemoveAccount(ac2);
            Assert.AreEqual(0, ac1.ChildAccounts.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAccountOnlyAppearsOnceInHierarchy()
        {
            CompositeAccount ac1 = new CompositeAccount("A");
            CompositeAccount ac2 = new CompositeAccount("B");
            CompositeAccount ac3 = new CompositeAccount("C");

            ac1.AddAccount(ac3);
            ac2.AddAccount(ac3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAccountsWithSameNameCannotShareParent()
        {
            CompositeAccount ac1 = new CompositeAccount("AC1");
            CompositeAccount ac2 = new CompositeAccount("ABC");
            CompositeAccount ac3 = new CompositeAccount("ABC");

            ac1.AddAccount(ac2);
            ac1.AddAccount(ac3);
        }

        [TestMethod]
        public void TestAccountsWithSameNameCanExistInHierarchy()
        {
            CompositeAccount ac1 = new CompositeAccount("AC1");
            CompositeAccount ac2 = new CompositeAccount("ABC");
            CompositeAccount ac3 = new CompositeAccount("AC3");
            CompositeAccount ac4 = new CompositeAccount("ABC");

            ac1.AddAccount(ac2);
            ac2.AddAccount(ac3);
            ac3.AddAccount(ac4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAccountsCannotBeDirectlyCyclical()
        {
            CompositeAccount ac1 = new CompositeAccount("AC1");
            CompositeAccount ac2 = new CompositeAccount("AC2");

            ac1.AddAccount(ac2);
            ac2.AddAccount(ac1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAccountsCannotBeIndirectlyCyclical()
        {
            CompositeAccount ac1 = new CompositeAccount("AC1");
            CompositeAccount ac2 = new CompositeAccount("AC2");
            CompositeAccount ac3 = new CompositeAccount("AC3");

            ac1.AddAccount(ac2);
            ac2.AddAccount(ac3);
            ac3.AddAccount(ac1);
        }
    }
}
