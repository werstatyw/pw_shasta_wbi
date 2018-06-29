﻿using System;
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
        public static String Get(String value)
		{
			return System.Configuration.ConfigurationManager.AppSettings[value];
		}
    }
}
