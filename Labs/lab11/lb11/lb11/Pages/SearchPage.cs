using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lb11.Loger.Loger;

namespace lb11.Pages
{
    internal class SearchPage : PageBase.PageBase
    {
        public SearchPage(IWebDriver driver) : base(driver) { }
        public void ClickSearchProduct()
        {
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div[1]/div[2]/div/div[2]/div[1]/div/div[1]")).Click();
            var windowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            Info("Product selected.");
        }

        public void ClickColor()
        {
           Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div[1]/div[1]/div/div/div[5]/div[2]/div[1]")).Click();
            Info("Color selected.");
        }

        public void BrandProduct(string brand)
        {
            IWebElement brandInput = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div[1]/div[1]/div/div/div[4]/div[2]/label/input"));
            brandInput.Click();
            brandInput.SendKeys(brand);
            brandInput.SendKeys(Keys.Enter);
            Info("Brand selected.");
        }

        public void SortProducts() 
        {
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div/div[2]/div/div[1]/div/div/div[1]/div[2]/div[1]/div")).Click();
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div/div[2]/div/div[1]/div/div[1]/div[1]/div[2]/div[2]/div/label[2]")).Click();
            Info("Sort selected");
        }


        public void PriceProducts(string from, string to)
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div[1]/div[1]/div/div/div[3]/div[2]/div/label[1]/input")).SendKeys(from);
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div[1]/div[1]/div/div/div[3]/div[2]/div/label[2]/input")).SendKeys(to);
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div[1]/div[1]/div/div/div[3]/div[2]/div/label[1]/input")).Click();
           
            Info("Price selected.");
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                //Driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div"));
                //Driver.Quit();
                Info("Product found.");
                return true;
            }
            catch (NoSuchElementException)
            {
                //Driver.Quit();
                Info("Product not found.");
                return false;
            }
        }
    }
}
