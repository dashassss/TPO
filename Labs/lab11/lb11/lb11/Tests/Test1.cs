﻿using lb11.Pages;
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
    public class Test1
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
            _mainPage.Search("сумка");
            _searchPage.ClickColor();

            Assert.IsTrue(_searchPage.isFound());

        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
