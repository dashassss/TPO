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
    public class Test5
    {
        private MainPage _mainPage;
        private SearchPage _searchPage;
        private ProductPage _productPage;
        private BasketPage _basketPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _searchPage = new SearchPage(Driver);
            _productPage = new ProductPage(Driver);
            _basketPage = new BasketPage(Driver);

        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.Search("вязаная игрушка");
            _searchPage.ClickSearchProduct();
            _productPage.BasketButton();
            _productPage.GoToBasket();
            _basketPage.AddProductsInBasket();

            Assert.IsTrue(_basketPage.IsDigit2Present());

        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
