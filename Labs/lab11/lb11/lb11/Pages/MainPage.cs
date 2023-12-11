using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lb11.Loger.Loger;

namespace lb11.Pages
{
    internal class MainPage : PageBase.PageBase
    {

        private readonly string _baseUrl = "https://aliexpress.ru";

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
            Info("Main page opened.");
        }

        public void Search(string searchText)
        {
            Thread.Sleep(2000);
            Info("Searching for " + searchText);
           // IWebElement searchInput = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/input"));
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/input")).SendKeys(searchText);
            //searchInput.SendKeys(searchText);
           // IWebElement searchButton = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/div/button[2]")); 
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/div/button[2]")).Click();
            //searchButton.Click();
            Info("Search completed.");
        }

        public void ClickCatalog()
        {
            IWebElement catalogButton = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/nav[1]/ul/li/button"));
            catalogButton.Click();
            Info("Catalog clicked.");
        }

        public void ClickCurrency(string currency)
        {
           // IWebElement currencyButton = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div[1]/div")); 
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div[1]/div")).Click();
            //currencyButton.Click();
            //IWebElement currencyInput = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/nav[1]/ul/li/button"));
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div[1]/div[2]/div/ul/div/div/div[2]/input")).SendKeys(currency);
            //currencyInput.SendKeys(currency);
           // IWebElement currencyLi = 
                Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div[1]/div[2]/div/ul/li")).Click();
            //currencyLi.Click();
            Info("Currency update.");
        }
        public void ClickLanguage()
        {
            IWebElement languageButton = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div[2]"));
            languageButton.Click();          
            IWebElement languageLi = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/div/div/div[2]/div[2]/div/ul/li[2]"));
            languageLi.Click();
            Info("Language update.");
        }

        public void ClickProduct() 
        {
            IWebElement productDiv = Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[9]/div/div/div[2]/div/div/div/div/div[1]"));
            productDiv.Click();
            var windowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            Info("Catalog clicked.");
        }
        public void ClickBenefit()
        {
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div[2]/header/div[1]/div/div[1]/div/div")).Click();
            Info("Benefit page clicked.");
        }

        public void HotProduct()
        {
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[6]/ul/li[1]/a")).Click();
            Info("Hot deals clicked.");
        }

        public void RecomendProducts()
        {
            Driver.FindElement(By.XPath("//*[@id=\"tab2\"]")).Click();
            Info("RecomendProducts clicked.");
        }
        public void RecomendSelectProducts()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[9]/div/div/div[2]/div/div/div/div/div[5]")).Click();
            var windowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            Info("RecomendSelectProducts clicked.");
        }



    }
}
