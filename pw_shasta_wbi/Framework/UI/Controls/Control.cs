using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
using NUnit.Framework;

namespace pw_shasta_wbi.Framework.UI.Controls
{
    public class Control
    {
		private IWebDriver driver;
		private By locator;

        public IWebDriver Driver
		{
			get
			{
				return driver;
			}
		}
        public By Locator
		{
			get
			{
				return locator;
			}
		}
        public IWebElement Element
		{
			get
			{
				return this.Driver.FindElement(this.Locator);
			}
		}
        public String Text
		{
			get
			{
				Assert.True(this.Exists(), "Unable to find element: " + this.Locator);
				return this.Element.Text;
			}
		}
        public Control(IWebDriver driverValue, By locatorValue)
        {
			driver = driverValue;
			locator = locatorValue;
        }
        public bool Exists(int timeout)
		{
			try
			{
				new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementExists(this.Locator));
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
			return true;
		}
        public bool Exists()
		{
			return Exists(Configuration.Timeout);
		}
		public bool Visible(int timeout)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
					.Until(ExpectedConditions.ElementExists(this.Locator));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }
        public bool Visible()
        {
            return Visible(Configuration.Timeout);
        }

        public void Click()
		{
			Assert.True(this.Exists(), "Unable to find element: " + this.Locator);
			Assert.True(this.Visible(), "Unable to wait for visibility of element: " + this.Locator);
			this.Element.Click();
		}
    }
}
