using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lb11.Loger.Loger;

namespace lb11.Pages
{
    internal class CatalogPage : PageBase.PageBase
    {
        public CatalogPage(IWebDriver driver) : base(driver) { }
        public void HoverOverElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }
        public void ClickCategory()
        {
            HoverOverElement(Driver.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[1]/a[2]")));

            Driver.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/div[2]/a[1]")).Click();
            Info("Click Category");
        }

    }
}
