using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace sogettiTest1
{
    [TestClass]
    public class AutomationCheckonSogettisite
    {       
        [TestMethod]
        public void TestMethod1()
        {
            //Driver Initialised, window Maximised and cookies accepted
            IWebDriver myDriver = initialiseDriverAndGotourlAndAcceptCookies();
            Thread.Sleep(1000);

            //Hovering over Services, clicking Automation, getting the color of the tabs before clicking
            Actions action = new Actions(myDriver);
            string serviceTabPath = "#main-menu > ul > li.has-children.level2.focus-style > div.wrapper > span";
            IWebElement serviceTab = myDriver.FindElement(By.CssSelector(serviceTabPath));
            string colorOfServiceTab = serviceTab.GetCssValue("color");
            Console.WriteLine(colorOfServiceTab);
            action.MoveToElement(serviceTab).Build().Perform();
            Thread.Sleep(2000);
            string automationTabPath = "#main-menu > ul > li.has-children.level2.focus-style > div.mega-navbar.refreshed.level2 > ul > li:nth-child(4) > a";
            string colorOfAutomationTabBeforeClicking = myDriver.FindElement(By.CssSelector(automationTabPath)).GetCssValue("color");
            Console.WriteLine(colorOfAutomationTabBeforeClicking);
            myDriver.FindElement(By.CssSelector(automationTabPath)).Click();
            Thread.Sleep(2000);
            
            //Asserting if the page is automation
            string title = myDriver.Title;
            Assert.AreEqual("Automation", title);
            if (true)
                Console.WriteLine("The title is Automation");
            Thread.Sleep(1000);

            //Assert if word Automation is Displayed
            var wordsInAutomationPageList = myDriver.FindElements(By.XPath("/html/body/div[1]/main/div[3]/div/div[2]/div/h1/span")); 
            foreach(var item in wordsInAutomationPageList)
            {
                string wordsInAutomationPage = item.Text;
                if( wordsInAutomationPage == "Automation")
                {
                    Console.WriteLine("Automation is Displayed");
                    break;
                }
            }
            Thread.Sleep(1000);

            // checking if service and Automation being selected
            string serviceTabPathAfeterSelecting = "#main-menu > ul > li.selected.has-children.expanded.level2.focus-style > div.wrapper > span";
            string colorOfServiceTabAfterSelecting = myDriver.FindElement(By.CssSelector(serviceTabPathAfeterSelecting)).GetCssValue("color");
            Console.WriteLine(colorOfServiceTabAfterSelecting);
            string AutomationTabPathAfterClicking = "#main-menu > ul > li.selected.has-children.expanded.level2.focus-style > div.mega-navbar.refreshed.level2 > ul > li.selected.current.expanded > a";
            string colorOfAutomationTabAfterClicking = myDriver.FindElement(By.CssSelector(AutomationTabPathAfterClicking)).GetCssValue("color");
            Console.WriteLine(colorOfAutomationTabAfterClicking);
            if (colorOfServiceTab == colorOfServiceTabAfterSelecting)
                Console.WriteLine("service is not selected");
            else
                Console.WriteLine("service is selected");
            if (colorOfAutomationTabBeforeClicking == colorOfAutomationTabAfterClicking)
                Console.WriteLine("Automation is not clicked");
            else
                Console.WriteLine("Automation is clicked");
            myDriver.Close();
            myDriver.Dispose();
        }

        public IWebDriver initialiseDriverAndGotourlAndAcceptCookies()
        {
            IWebDriver myDriver = new ChromeDriver();
            myDriver.Manage().Window.Maximize();
            myDriver.Navigate().GoToUrl("https://www.sogeti.com/");
            string acceptCookiesButtonPath = "#CookieConsent > div.consentcontent > div > div.flexcontainer > div.buttons > button.acceptCookie";
            myDriver.FindElement(By.CssSelector(acceptCookiesButtonPath)).Click();
            return myDriver;
        }
        
    }
}
