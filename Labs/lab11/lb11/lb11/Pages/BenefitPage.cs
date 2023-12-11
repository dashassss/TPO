using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lb11.Loger.Loger;

namespace lb11.Pages
{
    internal class BenefitPage : PageBase.PageBase
    {
        public BenefitPage(IWebDriver driver) : base(driver) { }

        public void ClickSport()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"tab-nav-5\"]")).Click();
        }
        public void ClickProductOne()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"TabOfFalls\"]/div[2]/div[3]")).Click();
            var windowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            Info("Product one selected.");
        }
        public void ClickProductTwo()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"TabOfFalls\"]/div[2]/div[4]")).Click();
            var windowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            Info("Product two selected.");
        }
        public void ClickProductThree()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"TabOfFalls\"]/div[2]/div[5]")).Click();
            var windowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            Info("Product three selected.");
        }
        public void ClickAdd() 
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[11]/div")).Click();
            Info("Product add to basket");
        }

        public void ClickExit()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]")).Click();
            Info("Product exit");
        }
        public void ClickButtons()
        {
            Thread.Sleep(2000);
            ClickAdd();
            ClickExit();
        }

        public void ClickBasket()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"root-GNhAhQrcKG\"]/div[4]/div/div[1]")).Click();
            Info("View the basket");
        }


        public bool IsProductInBasket()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"root-GNhAhQrcKG\"]/div[3]/div/div[2]/div"));
                Info("Product is in the basket.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Product is not in the basket.");
                return false;
            }
        }
    }
}
