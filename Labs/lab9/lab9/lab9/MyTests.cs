﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace lab9
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void AddItemToBasket()
        {
            WebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://aliexpress.ru");

            
            driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/input")).SendKeys("наушники");
            driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/div/button[2]")).Click();

            
            driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div/div[2]/div/div[2]/div[1]/div/div[1]")).Click();
            var windowHandles = driver.WindowHandles;
            
            driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            
            driver.FindElement(By.XPath("//*[@id=\"buyNowButton\"]/div/div[1]/button")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/nav[2]/ul/li[2]/button/div/a"));
            }
            catch
            {
                Assert.Fail("Элемент не найден");
            }
           
           
        }



    }
}
