using lb11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lb11.DriverManager.DriverMaganer;
using Assert = NUnit.Framework.Assert;

namespace lb11.Tests
{
    [TestClass]
    internal class Test8
    {
        private MainPage _mainPage;
        private BenefitPage _benefitPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _benefitPage = new BenefitPage(Driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.ClickBenefit();
            _benefitPage.ClickSport();
            _benefitPage.ClickProductOne();
            _benefitPage.ClickButtons();
            _benefitPage.ClickProductTwo();
            _benefitPage.ClickButtons();
            _benefitPage.ClickProductThree();
            _benefitPage.ClickButtons();
            _benefitPage.ClickBasket();
            Assert.IsTrue(_benefitPage.IsProductInBasket());

        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
