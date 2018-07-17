using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
using pw_shasta_wbi.Framework.UI.Controls;

namespace pw_shasta_wbi.Framework.UI
{
	public class Page
	{
		private IWebDriver driver;
		public IWebDriver Driver
		{
			get
			{
				return driver;
			}
		}
		public Page(IWebDriver driverValue)
		{
			driver = driverValue;
		}
		public virtual Page Navigate()
		{
			return this;
		}
		public bool IsTextPresent(String text)
		{
			String locatorText = String.Format("//*[text()='{0}' or contains(text(), '{1}')]", text, text);
			Control element = new Control(this, By.XPath(locatorText));
			return element.Exists();
		}
	}
}
