using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
using pw_shasta_wbi.Framework.UI;
using pw_shasta_wbi.Framework.UI.Controls;

namespace pw_shasta_wbi.Pages
{
	public class SearchPage : Page
	{
	[FindBy("UserName")]	
		public Edit editUsername;
		[FindBy("Password")]
        public Edit editPassword;
		[FindBy("btnLogin")]
        public Control buttonLogin;
		[FindBy("link=Logout")]
		public Control linkLogout;
		public SearchPage (IWebDriver driver) : base(driver)
		{
		}
		public override Page Navigate()
		{
			String baseURL = Configuration.Get("BaseURL");
            Driver.Navigate().GoToUrl(baseURL);
			return this;
		}
	}
}