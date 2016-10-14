using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyMoney.Model;

namespace MyMoney.ViewModel.Test
{
    /// <summary>
    /// Summary description for MoneyViewModelTest
    /// </summary>
    [TestClass]
    public class MoneyViewModelTest
    {
        [TestMethod]
        public void TestSimpleGBPAmount()
        {
            Money money = new Money(123.45M, new CultureInfo("en-GB"));
            MoneyViewModel moneyViewModel = new MoneyViewModel(money);

            Assert.AreEqual("£123.45", moneyViewModel.DisplayValue);
        }
        
        [TestMethod]
        public void TestSimpleUSDAmount()
        {
            Money money = new Money(123.45M, new CultureInfo("en-US"));
            MoneyViewModel moneyViewModel = new MoneyViewModel(money);

            Assert.AreEqual("$123.45", moneyViewModel.DisplayValue);
        }

        [TestMethod]
        public void TestNegativeGBPAmount()
        {
            Money money = new Money(-123.45M, new CultureInfo("en-GB"));
            MoneyViewModel moneyViewModel = new MoneyViewModel(money);

            Assert.AreEqual("-£123.45", moneyViewModel.DisplayValue);
        }

        [TestMethod]
        public void TestNegativeUSDAmount()
        {
            Money money = new Money(-123.45M, new CultureInfo("en-US"));
            MoneyViewModel moneyViewModel = new MoneyViewModel(money);

            Assert.AreEqual("($123.45)", moneyViewModel.DisplayValue);
        }
    }
}

