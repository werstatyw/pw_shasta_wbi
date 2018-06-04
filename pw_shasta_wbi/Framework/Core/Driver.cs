using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace pw_shasta_wbi.Framework.Core
{
    public class Driver
    {
		private static IWebDriver driver;
		private static Dictionary<String, Type> driverMap = new Dictionary<string, Type>()
		{
			{"chrome", typeof(ChromeDriver)},
			{"firefox", typeof(FirefoxDriver)},
			{"ie", typeof(InternetExplorerDriver)},
			{"opera", typeof(OperaDriver)},
			{"safari", typeof(SafariDriver)}
		};
		private static Dictionary<String, Type> optionsMap = new Dictionary<string, Type>()
        {
            {"chrome", typeof(ChromeOptions)},
            {"firefox", typeof(FirefoxOptions)},
            {"ie", typeof(InternetExplorerOptions)},
            {"opera", typeof(OperaOptions)},
            {"safari", typeof(SafariOptions)}
        };
		private Driver()
        {
        }

        public static void Add(String browser, String path, ICapabilities capabilities)
		{
			Type driverType = driverMap[browser];
			DriverOptions options = (DriverOptions)optionsMap[browser].GetConstructor(new Type[] { }).Invoke(new object[] { });
			if (browser == "firefox")
			{
				driver = new FirefoxDriver((FirefoxOptions) options);
			}
			else
			{
				driver = (IWebDriver)driverType.GetConstructor(new Type[] { typeof(String), optionsMap[browser] }).Invoke(new Object[] { path, options });
			}
		}
        public static IWebDriver Current()
		{
			return driver;
		}
    }
}
