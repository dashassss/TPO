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
    internal class Test9
    {
        private MainPage _mainPage;
        private HotDealsPage _hotDealsPage;
        private ProductPage _productPage;


        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _hotDealsPage = new HotDealsPage(Driver);
            _productPage = new ProductPage(Driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.HotProduct();
            _hotDealsPage.BeautyClick();
            _hotDealsPage.ClickProduct();
            _productPage.BasketButton();
            _productPage.GoToBasket();

            Assert.IsTrue(_productPage.IsProductInBasket());

        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
