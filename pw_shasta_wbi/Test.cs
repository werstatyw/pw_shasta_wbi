using NUnit.Framework;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
using pw_shasta_wbi.Framework.UI;
using pw_shasta_wbi.Framework.UI.Controls;
using pw_shasta_wbi.Pages;
            
namespace pw_shasta_wbi
{
    [TestFixture()]
    public class Test
    {
		private String baseURL;
		private IWebDriver driver;
		private SearchPage searchPage;
		private SearchResultsPage searchResultsPage;

        [SetUp]
        public void SetUp()
		{
			baseURL = Configuration.Get("BaseURL");
			ChromeOptions options = new ChromeOptions();
			DesiredCapabilities capabilities = new DesiredCapabilities();
			Driver.Add(Configuration.Get("Browser"),Path.GetFullPath("/home/wers4/Projects/pw_shasta_wbi/pw_shasta_wbi"), capabilities);
            searchPage = PageFactory.Init<SearchPage>();
			searchPage.Navigate();
		}
        [TearDown]
        public void TearDown()
		{
			Driver.Quit();
		}
		static Object[] LoginData =
		{
		//	new Object [] {"", "test"},
		//	new Object [] {"test", ""},
			new Object [] {"werstatyw", "pwd!"},
		};
        [Test(), TestCaseSource("LoginData")]
        public void TestCase(String username, String password)
        {
			searchPage.editUsername.Text = username;
			searchPage.editPassword.Text = password;
			//Edit editUsername = new Edit(this, By.Id("UserName"));
			//Edit editPassword = new Edit(driver, By.Id("Password"));
		//	Control autoCompleteItem = new Control(driver, By.XPath("(//li(contains(@class, 'autocomplete_item')])"));
		//	Control checkoutDayToday = new Control(driver, By.CssSelector("i.sb-date-field_chevron.bicon-downchevron"));
		//	Control radioLeisure = new Control(driver, By.XPath("(//input(@name='sb_travel_purpose'])[2]"));
		//	Control radioBusiness = new Control(driver, By.XPath("(//input(@name='sb_travel_purpose'])[1]"));
		//	SelectList selectAdultsNumber =  new SelectList(driver, By.Id("group_adults"));
		//	Control buttonLogin = new Control(driver, By.Id("btnLogin"));
		//	Control buttonLogout = new Control(driver, By.LinkText("Logout"));
			//editUsername.Text = username;
			//editPassword.Text = password;
			searchPage.buttonLogin.Click();
			searchPage.linkLogout.Click();
			//autoCompleteItem.Click();

			/*	driver.FindElement(By.Id("UserName")).Clear();
				driver.FindElement(By.Id("UserName")).SendKeys(username);
				driver.FindElement(By.Id("Password")).Click();
				driver.FindElement(By.Id("Password")).Clear();
				driver.FindElement(By.Id("Password")).SendKeys(password);
				driver.FindElement(By.Id("btnLogin")).Click();
	//			System.Threading.Thread.Sleep(1000);
				driver.FindElement(By.Id("Logout")).Click();*/
			searchResultsPage = PageFactory.Init<SearchResultsPage>();
			searchResultsPage.editPassword.Click();
			Assert.True(searchResultsPage.IsTextPresent(password));
			searchResultsPage.CaptureScreenShot(Path.GetFullPath("/home/wers4/Pictures/screenshot.png"));
        }
    }
}
