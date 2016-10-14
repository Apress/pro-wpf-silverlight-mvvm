using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyMoney.Model.Test
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void TestMoneyAddition()
        {
            Money value1 = 10M;
            Money value2 = 5M;
            Money result = value1 + value2;

            Assert.AreEqual(new Money(15M), result);
        }

        [TestMethod]
        public void TestMoneySubtraction()
        {
            Money value1 = 10M;
            Money value2 = 5M;
            Money result = value1 - value2;

            Assert.AreEqual(new Money(5M), result);
        }

        [TestMethod]
        public void TestDecimalAddition()
        {
            Money value1 = 10M;
            decimal value2 = 5M;
            Money result = value1 + value2;

            Assert.AreEqual(new Money(15M), result);
        }

        [TestMethod]
        public void TestDecimalSubtraction()
        {
            Money value1 = 10M;
            decimal value2 = 5M;
            Money result = value1 - value2;

            Assert.AreEqual(new Money(5M), result);
        }

        [TestMethod]
        public void TestIntegerDivision()
        {
            Money value1 = 10M;
            int value2 = 5;
            Money result = value1 / value2;

            Assert.AreEqual(new Money(2M), result);
        }

        [TestMethod]
        public void TestIntegerMultiplication()
        {
            Money value1 = 10M;
            int value2 = 5;
            Money result = value1 * value2;

            Assert.AreEqual(new Money(50M), result);
        }

        [TestMethod]
        public void TestMoneyEquality()
        {
            Money value1 = 10M;
            Money value2 = 10M;
            Money value3 = 5M;
            bool result1 = value1 == value2;
            bool result2 = value2 == value1;
            bool result3 = value2 == value3;
            bool result4 = value3 == value2;

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void TestMoneyInequality()
        {
            Money value1 = 10M;
            Money value2 = 10M;
            Money value3 = 5M;
            bool result1 = value1 != value2;
            bool result2 = value2 != value1;
            bool result3 = value2 != value3;
            bool result4 = value3 != value2;

            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
        }

        [TestMethod]
        public void TestMoneyGreaterThan()
        {
            Money value1 = 10M;
            Money value2 = 5M;
            bool result1 = value1 > value2;
            bool result2 = value2 > value1;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void TestMoneyLessThan()
        {
            Money value1 = 10M;
            Money value2 = 5M;
            bool result1 = value1 < value2;
            bool result2 = value2 < value1;

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void TestMoneyGreaterThanOrEqualTo()
        {
            Money value1 = 10M;
            Money value2 = 10M;
            bool result1 = value1 >= value2;
            bool result2 = value2 >= value1;

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void TestMoneyLessThanOrEqualTo()
        {
            Money value1 = 10M;
            Money value2 = 10M;
            bool result1 = value1 <= value2;
            bool result2 = value2 <= value1;

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void TestMoneyAddition_WithDifferentCurrencies()
        {
            Money value1 = new Money(10M, new CultureInfo("en-US"));
            Money value2 = new Money(5M, new CultureInfo("en-GB"));
            Money result = value1 + value2;

            Assert.AreEqual(Money.Undefined, result);
        }

        [TestMethod]
        public void TestMoneySubtraction_WithDifferentCurrencies()
        {
            Money value1 = new Money(10M, new CultureInfo("en-US"));
            Money value2 = new Money(10M, new CultureInfo("en-GB"));
            Money result = value1 - value2;

            Assert.AreEqual(Money.Undefined, result);
        }

        [TestMethod]
        [ExpectedException(typeof(CurrencyMismatchException))]
        public void TestMoneyGreaterThan_WithDifferentCurrencies()
        {
            Money value1 = new Money(10M, new CultureInfo("en-US"));
            Money value2 = new Money(5M, new CultureInfo("en-GB"));
            
            bool result = value1 > value2;
        }

        [TestMethod]
        [ExpectedException(typeof(CurrencyMismatchException))]
        public void TestMoneyLessThan_WithDifferentCurrencies()
        {
            Money value1 = new Money(10M, new CultureInfo("en-US"));
            Money value2 = new Money(5M, new CultureInfo("en-GB"));

            bool result = value1 < value2;
        }

        [TestMethod]
        [ExpectedException(typeof(CurrencyMismatchException))]
        public void TestMoneyGreaterThanOrEqualTo_WithDifferentCurrencies()
        {
            Money value1 = new Money(10M, new CultureInfo("en-US"));
            Money value2 = new Money(5M, new CultureInfo("en-GB"));

            bool result = value1 >= value2;
        }

        [TestMethod]
        [ExpectedException(typeof(CurrencyMismatchException))]
        public void TestMoneyLessThanOrEqualTo_WithDifferentCurrencies()
        {
            Money value1 = new Money(10M, new CultureInfo("en-US"));
            Money value2 = new Money(5M, new CultureInfo("en-GB"));

            bool result = value1 <= value2;
        }
    }
}
