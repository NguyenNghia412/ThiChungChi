using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Thi_SV.Common
{
    public static class ConfigManager
    {
        public static string TemporaryFolder = "TempFolder";
        public static string UploadsFolder = "UploadsFolder";
        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}