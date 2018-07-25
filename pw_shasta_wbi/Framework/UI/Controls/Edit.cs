using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using pw_shasta_wbi.Framework.Core;
using NUnit.Framework;

namespace pw_shasta_wbi.Framework.UI.Controls
{
	public class Edit : Control
    {
		public new String Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				this.Click();
				this.Element.Clear();
				this.Element.SendKeys(value);
			}
		}
		public Edit(Page pageValue, By locator) : base(pageValue, locator)
        {
        }
    }
}
