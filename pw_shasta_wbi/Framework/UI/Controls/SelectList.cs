using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
using NUnit.Framework;
namespace pw_shasta_wbi.Framework.UI.Controls
{
	public class SelectList : Control
    {
		public SelectElement Select
		{
			get
			{
				return new SelectElement(base.Element);
			}
		}
        public new String Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				this.Select.SelectByText(value);
			}
		}
		public SelectList(IWebDriver driver, By locator) : base(driver, locator)
        {
        }
    }
}
