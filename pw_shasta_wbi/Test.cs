using NUnit.Framework;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
            
namespace pw_shasta_wbi
{
    [TestFixture()]
    public class Test
    {
		private String baseURL;
		private IWebDriver driver;

        [SetUp]
        public void SetUp()
		{
			baseURL = Configuration.Get("BaseURL");
			ChromeOptions options = new ChromeOptions();
			DesiredCapabilities capabilities = new DesiredCapabilities();
			Driver.Add(Configuration.Get("Browser"),Path.GetFullPath("/home/wers4/Projects/pw_shasta_wbi/pw_shasta_wbi"), capabilities);
			driver = Driver.Current();
            driver.Navigate().GoToUrl(baseURL);
		}
        [TearDown]
        public void TearDown()
		{
			driver.Quit();
		}
        [Test()]
        public void TestCase()
        {
			driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("werstatyw");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("xAcdxehs1348!");
            driver.FindElement(By.Id("btnLogin")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
             
    
}
