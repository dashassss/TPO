using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace lab9
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ICanWin()
        {
            WebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pastebin.com");
            driver.FindElement(By.Id("postform-text")).SendKeys("Hello from WebDriver");

            driver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            driver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            driver.FindElement(By.Id("postform-name")).SendKeys("helloweb");
            driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[10]/button")).Click();

            //driver.Quit();
        }

        [TestMethod]
        public void BringItOn()
        {
            WebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pastebin.com");
            driver.FindElement(By.Id("postform-text")).SendKeys("git config --global user.name  \"New Sheriff in Town\"" + "\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\") " + "\ngit push origin master --force");


            driver.FindElement(By.Id("select2-postform-format-container")).Click();
            driver.FindElement(By.XPath("//li[text()='Bash']")).Click();

            driver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            driver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            driver.FindElement(By.Id("postform-name")).SendKeys("how to gain dominance among developers");
            driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[10]/button")).Click();

            WebElement syntax = (WebElement)driver.FindElement(By.XPath("//a[text()='Bash']"));
            WebElement gitCodeFirstLine = (WebElement)driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div[4]/div[2]/ol/li[1]/div"));
            WebElement gitCodeSecondLine = (WebElement)driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div[4]/div[2]/ol/li[2]/div"));
            WebElement gitCodeThirdLine = (WebElement)driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div[4]/div[2]/ol/li[3]/div"));

            Assert.AreEqual("Bash", syntax.Text);
            Assert.IsTrue(gitCodeFirstLine.Text.StartsWith("git config"));
            Assert.IsTrue(gitCodeSecondLine.Text.StartsWith("git reset"));
            Assert.IsTrue(gitCodeThirdLine.Text.StartsWith("git push"));


            //driver.Quit();
        }

        [TestMethod]
        public void HurtMePlenty()
        {
            /*WebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cloud.google.com/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).Click();

            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).SendKeys("Google Cloud Platform Pricing Calculator");
            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//*[@id=\"___gcse_0\"]/div/div/div/div[5]/div[2]/div/div/div[1]/div[1]/div[1]/div[1]/div/a")).Click();


            //  driver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[1]/div[1]/md-input-container")).SendKeys("4");
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            *//*            IWebDriver el = (IWebDriver)driver.FindElement(By.XPath("//*[@id=\"select_value_label_94\"]"));

                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        wait.Until()*//*
            driver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[1]")).Click();

            driver.FindElement(By.XPath("/html/body/md-content/md-card/div/md-card-content[1]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[1]/div[1]/md-input-container/input")).SendKeys("4");

*/
            //driver.Quit();


            WebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cloud.google.com/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).SendKeys("Google Cloud Platform Pricing Calculator");
            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//*[@id=\"___gcse_0\"]/div/div/div/div[5]/div[2]/div/div/div[1]/div[1]/div[1]/div[1]/div/a")).Click();

            // Wait for the Pricing Calculator page to load
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            // Activate the COMPUTE ENGINE section
            driver.FindElement(By.XPath("//md-tab-item/div/div[contains(text(), 'COMPUTE ENGINE')]")).Click();

            // Fill in the form
            driver.FindElement(By.XPath("//label[contains(text(), 'Number of instances')]/following-sibling::input[1]")).SendKeys("4");

            

            // Select the operating system
            driver.FindElement(By.XPath("//label[contains(text(), 'Operating System / Software')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), 'Free: Debian, CentOS, CoreOS, Ubuntu, or other User Provided OS')]")).Click();

            // Select the VM class
            driver.FindElement(By.XPath("//label[contains(text(), 'VM Class')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), 'Regular')]")).Click();

            // Select the instance type
            driver.FindElement(By.XPath("//label[contains(text(), 'Instance type')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), 'n1-standard-8 (vCPUs: 8, RAM: 30 GB)')]")).Click();

            // Add GPUs
            driver.FindElement(By.XPath("//label[contains(text(), 'Add GPUs')]/following-sibling::md-checkbox/div")).Click();

            // Select the number of GPUs
            driver.FindElement(By.XPath("//label[contains(text(), 'Number of GPUs')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), '1')]")).Click();

            // Select the GPU type
            driver.FindElement(By.XPath("//label[contains(text(), 'GPU type')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), 'NVIDIA Tesla V100')]")).Click();

            // Select local SSD
            driver.FindElement(By.XPath("//label[contains(text(), 'Local SSD')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), '2x375 Gb')]")).Click();

            // Select datacenter location
            driver.FindElement(By.XPath("//label[contains(text(), 'Datacenter location')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), 'Frankfurt (europe-west3)')]")).Click();

            // Select committed usage
            driver.FindElement(By.XPath("//label[contains(text(), 'Committed usage')]/following-sibling::md-select")).Click();
            driver.FindElement(By.XPath("//md-option/div[contains(text(), '1 Year')]")).Click();

            // Add to estimate
            driver.FindElement(By.XPath("//button[contains(text(), 'Add to Estimate')]")).Click();

            // Verify the selected options
            string vmClass = driver.FindElement(By.XPath("//div[contains(text(), 'VM class')]/following-sibling::div")).Text;
            string instanceType = driver.FindElement(By.XPath("//div[contains(text(), 'Instance type')]/following-sibling::div")).Text;
            string region = driver.FindElement(By.XPath("//div[contains(text(), 'Region')]/following-sibling::div")).Text;
            string localSSD = driver.FindElement(By.XPath("//div[contains(text(), 'local SSD')]/following-sibling::div")).Text;
            string commitmentTerm = driver.FindElement(By.XPath("//div[contains(text(), 'Commitment term')]/following-sibling::div")).Text;

            Console.WriteLine("VM Class: " + vmClass);
            Console.WriteLine("Instance Type: " + instanceType);
            Console.WriteLine("Region: " + region);
            Console.WriteLine("Local SSD: " + localSSD);
            Console.WriteLine("Commitment Term: " + commitmentTerm);

            // Verify the monthly cost
            string monthlyCost = driver.FindElement(By.XPath("//h2[contains(text(), 'Estimated Component Cost')]/following-sibling::h2")).Text;
            Console.WriteLine("Monthly Cost: " + monthlyCost);

            // Close the browser
            //driver.Quit();
        }
    }
}
