using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Amazone290322
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Driver Initialized, Url opened and Cookies accepted
            IWebDriver webdriver = InitializeDriverGoToUrlAndAcceptCookies();
            Thread.Sleep(2000);

            //Searching for the first Item "X box"
            string object1 = "X Box 512GB";
            webdriver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(object1);
            webdriver.FindElement(By.Id("nav-search-submit-button")).Click();
            webdriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div/span[3]/div[2]/div[3]/div/div/div/div/div/div[2]/div/div/div[1]/h2/a/span")).Click();
            webdriver.FindElement(By.Name("submit.add-to-cart")).Click();
            webdriver.SwitchTo().Window(webdriver.WindowHandles[1]);
            webdriver.FindElement(By.Id("attachSiNoCoverage-announce")).Click();
            //IWebElement nothanksTab = webdriver.FindElement(By.ClassName("a-button a-button-grouplast a-button-base"));
            //actions.MoveToElement(nothanksTab).Build().Perform();
            //actions.MoveToElement(nothanksTab).Click();

            Thread.Sleep(2000);
        }

         public IWebDriver InitializeDriverGoToUrlAndAcceptCookies()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.de/");
            string acceptCookiesPath = "#sp-cc-accept";
            driver.FindElement(By.CssSelector(acceptCookiesPath)).Click();
            return driver;
        }

        //public we SearchAndAddToCart(object1);
        //{

        //}
    }
}
