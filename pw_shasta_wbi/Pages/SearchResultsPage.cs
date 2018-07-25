using System;
using OpenQA.Selenium;
using pw_shasta_wbi.Framework.UI;
using pw_shasta_wbi.Framework.UI.Controls;

namespace pw_shasta_wbi.Pages
{
	public class SearchResultsPage : Page
    {
		[FindBy("Password")]
		public Edit editPassword;
		public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
