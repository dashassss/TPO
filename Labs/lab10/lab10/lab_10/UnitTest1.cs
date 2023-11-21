using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
namespace lab_10
{
    [TestClass]
    public class AliExpressTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
        }

        public class AliExpressHomePage
        {
            private readonly IWebDriver driver;

            public AliExpressHomePage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public void NavigateToHomePage(string url)
            {
                driver.Navigate().GoToUrl(url);
            }

            public void SearchForItem(string itemName)
            {
                IWebElement searchInput = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/input"));
                searchInput.SendKeys(itemName);

                IWebElement searchButton = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[3]/div/header/div[2]/form/fieldset/div/button[2]"));
                searchButton.Click();
            }

            public void ClickOnFirstSearchResult()
            {
                IWebElement firstSearchResult = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div/div[2]/div/div[2]/div[1]/div/div[1]/div/a"));

                firstSearchResult.Click();

                var windowHandles = driver.WindowHandles;
                driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            }

            public void ClickCheckboxFiltering()
            {
                // «десь используйте методы WebDriver дл€ поиска и взаимодействи€ с чекбоксом
                IWebElement checkbox = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div/div[1]/div/div/div[5]/div[2]/div[3]"));
                checkbox.Click();
               
            }

            public void ClickSortButton()
            {
                IWebElement sortName = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div/div[2]/div/div[1]/div/div/div[1]/div[2]/div[1]/div"));
                sortName.Click();
                ////*[@id="__aer_root__"]/div/div[5]/div/div/div[2]/div/div[1]/div/div/div[1]/div[2]/div[2]/div/label[2]
                ///////*[@id=\"__aer_root__\"]/div/div[5]/div/div/div[1]/div/div/div[5]/div[2]/div[3]/label
                IWebElement labelSortName = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[7]/div/div/div[2]/div/div[1]/div/div[1]/div[1]/div[2]/div[2]/div/label[2]"));
                labelSortName.Click();
            }
        }

        public class ProductPage
        {
            private readonly IWebDriver driver;

            public ProductPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public void ClickBuyNowButton()
            {
                IWebElement buyButton = driver.FindElement(By.XPath("//*[@id=\"buyNowButton\"]/div/div[1]/button"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", buyButton);
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    IWebElement element = driver.FindElement(By.XPath("//*[@id=\"__aer_root__\"]/div/div[4]/div/header/div[2]/nav[2]/ul/li[2]/button"));
                }
                catch
                {
                    Assert.Fail("Ёлемент не найден");
                }
            }
        }

        [TestMethod]
        public void AddItemToBasketTest()
        {
            AliExpressHomePage homePage = new AliExpressHomePage(driver);
            homePage.NavigateToHomePage("https://aliexpress.ru");
            homePage.SearchForItem("сумка");
            homePage.ClickCheckboxFiltering();
            homePage.ClickSortButton();
            homePage.ClickOnFirstSearchResult();

            ProductPage productPage = new ProductPage(driver);
            productPage.ClickBuyNowButton();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //driver.Quit();
        }
    }
}