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
    internal class ProductPage : PageBase.PageBase
    {
        public ProductPage(IWebDriver driver): base(driver) { }

        public void BasketButton()
        {
            Thread.Sleep(1000);
            //Driver.FindElement(By.XPath("//*[@id=\"buyNowButton\"]/div/div[1]/button")).Click();
            IWebElement buyButton = Driver.FindElement(By.XPath("//*[@id=\"buyNowButton\"]/div/div[1]/button"));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", buyButton);
            Info("Product add to basket");
        }

        public void GoToBasket()
        {
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[4]/div/header/div[2]/nav[2]/ul/li[2]/button/div/a")).Click();
            Info("Go to Basket.");
            
        }

        public void BuyNow()
        {
            Driver.FindElement(By.XPath("//*[@id=\"buyNowButton\"]/div/div[2]/button")).Click();
            Info("Buy now selected");
        }
        public bool IsProductInBasket()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div/div[1]/div[3]/div[1]/div"));
                Info("Product is in basket.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Product is not in basket.");
                return false;
            }
        }
        public bool IsDivInProduct()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"characteristics_anchor\"]"));
                Info("Div in the product.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Div is not in the product.");
                return false;
            }
        }

    }
}
