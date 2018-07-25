using System;
using System.Reflection;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using pw_shasta_wbi.Framework.Core;
using pw_shasta_wbi.Framework.UI.Controls;
namespace pw_shasta_wbi.Framework.UI
{
    public class PageFactory
    {
        private PageFactory()
        {
        }
        private static By toLocator(String input)
		{
			if (Regex.IsMatch(input, "^(xpath=|/)(.*)"))
			{
				return By.XPath(new Regex("^xpath=").Replace(input, ""));
			}
			else if (Regex.IsMatch(input, "^id=(.*)"))
			{
				return By.Id(input.Substring("id=".Length));
			}
			else if (Regex.IsMatch(input, "^link=(.*)"))
            {
                return By.LinkText(input.Substring("link=".Length));
            } 
            //additional thing for css, name, class, construction is similar to Id
	 	else
			{
				return By.Id(input);
			}
		}
		public static T Init<T>() where T : Page
		{
			IWebDriver driver = Driver.Current();
			T page = (T)typeof(T).GetConstructor(new Type[] { typeof(IWebDriver)})
				                 .Invoke(new Object[] { driver });

            foreach (FieldInfo field in typeof(T).GetFields())
			{
				FindByAttribute locator = (FindByAttribute)field.GetCustomAttribute(typeof(FindByAttribute));
				if (locator != null)
				{
					Control control = (Control)field.FieldType
													  .GetConstructor(new Type[] { typeof(Page), typeof(By)})
					                                 .Invoke(new Object[] { page, toLocator(locator.Locator)});
					field.SetValue(page, control);
				}
			}

			return page;
		}
    }
}
