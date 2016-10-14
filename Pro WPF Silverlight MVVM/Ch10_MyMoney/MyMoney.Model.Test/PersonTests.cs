using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyMoney.Model.Test
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void TestAddAccount()
        {
            Person person = new Person();
            CompositeAccount account1 = new CompositeAccount("AC1");
            LeafAccount account2 = new LeafAccount("AC2");
            
            person.AddAccount(account1);
            person.AddAccount(account2);

            Assert.AreEqual(2, person.Accounts.Count());
        }

        [TestMethod]
        public void TestRemoveAccount()
        {
            Person person = new Person();
            CompositeAccount account1 = new CompositeAccount("AC1");
            LeafAccount account2 = new LeafAccount("AC2");

            person.AddAccount(account1);
            person.AddAccount(account2);

            person.RemoveAccount(account1);
            person.RemoveAccount(account2);

            Assert.AreEqual(0, person.Accounts.Count());
        }

        [TestMethod]
        public void TestNetWorth()
        {
            Person person = new Person();
            CompositeAccount account1 = new CompositeAccount("AC1");
            LeafAccount account2 = new LeafAccount("AC2", 200M);
            LeafAccount account3 = new LeafAccount("AC3");
            LeafAccount account4 = new LeafAccount("AC4");

            account1.AddAccount(account2);
            account1.AddAccount(account3);
            account1.AddAccount(account4);
            person.AddAccount(account1);
            

            account2.AddEntry(new Entry(EntryType.Deposit, 20.75M));
            account2.AddEntry(new Entry(EntryType.Withdrawal, 11.13M));

            account3.AddEntry(new Entry(EntryType.Deposit, 1220.67M));
            account3.AddEntry(new Entry(EntryType.Withdrawal, 654.44M));

            account4.AddEntry(new Entry(EntryType.Withdrawal, 110.98M));

            Assert.AreEqual(new Money(664.87M), person.NetWorth);
        }
    }
}
