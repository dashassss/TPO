using lb11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
using static lb11.DriverManager.DriverMaganer;

namespace lb11.Tests
{
    [TestClass]
    public class Test4
    {
        private MainPage _mainPage;
        private SearchPage _searchPage;
        private ProductPage _productPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _searchPage = new SearchPage(Driver);
            _productPage = new ProductPage(Driver);

        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.ClickCurrency("USD");
            _mainPage.Search("джинсы");
            _searchPage.ClickSearchProduct();
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
