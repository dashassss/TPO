using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lb11.Loger.Loger;


namespace lb11.Pages
{
    internal class HotDealsPage : PageBase.PageBase
    {
        public HotDealsPage(IWebDriver driver) : base(driver) { }

        public void BeautyClick()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"tab-nav-3\"]/div")).Click();
            Info("Beauty part clicked.");
        }

        public void ClickProduct()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//*[@id=\"7902216270\"]/div/div[3]/div[3]")).Click();
            var windowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            Info("Product selected.");
        }
    }
}
