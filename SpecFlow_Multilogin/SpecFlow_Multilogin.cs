using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow_Multilogin
{
    [Binding]
    public class SpecFlow_Multilogin
    {

        public static IWebDriver driver;
        [Given(@"Open the google browser")]
        public void GivenOpenTheGoogleBrowser()
        {
            driver = new ChromeDriver();
        }

        [Given(@"enter the URL")]
        public void GivenEnterTheURL()
        {
            driver.Navigate().GoToUrl("http://localhost:64237/");
        }
        
        [When(@"I enter valid (.*)")]
        public void WhenIEnterValid(string p0)
        {
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("identifierId")).SendKeys(p0);
            driver.FindElement(By.Id("identifierNext")).Click();
            Thread.Sleep(3000);
        }

        [When(@"valid (.*) to sign in")]
        public void WhenValidToSignIn(string p0)
        {
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(p0);
            driver.FindElement(By.Id("passwordNext")).Click();
            Thread.Sleep(3000);
        }

        [Then(@"(.*) should be able to login successfully")]
        public void ThenShouldBeAbleToLoginSuccessfully(string p0)
        {
            string username = driver.FindElement(By.XPath("//span[@style='font-size:small']")).Text;
            string user = p0;
            Assert.AreEqual(user, username);
        }

        [Then(@"user log out from the application")]
        public void ThenUserLogOutFromTheApplication()
        {
            IWebElement logout = driver.FindElement(By.XPath("//a[@href='../api/logout']"));
            Actions mousehover = new Actions(driver);
            mousehover.MoveToElement(driver.FindElement(By.XPath("//li[@ng-controller='TopBarController']"))).MoveToElement(logout).Click().Build().Perform();
            /*
            mousehover.MoveToElement(logout).Click().Build().Perform();
            logout.SendKeys(Keys.Enter);
            */
            // / html / body / div[1] / div / div[3] / div / ul / li[4] / ul / li / a

        }

    }
}
