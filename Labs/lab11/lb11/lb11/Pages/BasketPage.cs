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
    internal class BasketPage:PageBase.PageBase
    {
        public BasketPage(IWebDriver driver): base(driver) { }    
        
        public void AddProductsInBasket()
        {
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[3]/div/div/button[2]")).Click();

            Info("Count products increase in basket");
        }

        public void RemoveProductsInBasket()
        {
            IWebElement removeButton = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/button[1]"));
            removeButton.Click();
            IWebElement confirmationButton = Driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/div/button[2]"));
            confirmationButton.Click();
            Info("Count products decrease in basket");
        }

        public bool IsDigit2Present()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[3]/div/div/span"));
                string elementText = element.Text;

                if (elementText.Contains("2"))
                {
                    Info("Element contains the digit 2.");
                    return true;
                }
                else
                {
                    Info("Element does not contain the digit 2.");
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                Info("Element not found.");
                return false;
            }
        }
    }
}
