using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
using NUnit.Framework;

namespace pw_shasta_wbi.Framework.UI.Controls
{
    public class Control
    {
		private Page page;
		private By locator;

		public Page Page
		{
			get
			{
				return page;
			}
		}

        public IWebDriver Driver
		{
			get
			{
				return Page.Driver;
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
        public Control(Page pageValue, By locatorValue)
        {
			this.page = pageValue;
			this.locator = locatorValue;
        }
        public bool Exists(int timeout)
		{
			try
			{
				new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementExists(this.Locator));
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
                new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout))
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
