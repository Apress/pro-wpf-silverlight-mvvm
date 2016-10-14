using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyMoney.Model;

namespace MyMoney.ViewModel.Test
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void ItShouldDelegateToThePersonForTheNetWorth()
        {
            MockPerson person = new MockPerson(new Person());
            MainWindowViewModel viewModel = new MainWindowViewModel(person);

            MoneyViewModel netWorth = viewModel.NetWorth;

            Assert.IsTrue(person.NetWorthWasRequested);
        }
    }
}
