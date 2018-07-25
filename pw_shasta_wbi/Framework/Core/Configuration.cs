using System;
using System.IO;
using pw_shasta_wbi.Framework.UI;
namespace pw_shasta_wbi.Framework.Core
{
    public class Configuration
    {
        private Configuration()
        {
        }
        public static int Timeout
		{
			get
			{
				return Int32.Parse(Get("timeout"));
			}
		}
        public static TargetPlatform Platform
        {
            get
            {
                return TargetPlatformMethods.Value(Get("Browser"));
            }
        }
        public static String DriverPath
        {
            get
            {
                String path = Get("DriverPath");
                if (!path.StartsWith("http:"))
                {
                    return Path.GetFullPath(path);
                }
               return path;
            }   
        }
        public static String Get(String value)
		{
			return System.Configuration.ConfigurationManager.AppSettings[value];
		}
    }
}
