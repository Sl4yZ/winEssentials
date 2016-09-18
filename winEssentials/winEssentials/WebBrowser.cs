using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace winEssentials
{
    class WebBrowser
    {
        public static string getDefault()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");

            string defaultWebB = key.GetValue("ProgId").ToString();

            switch (defaultWebB)
            {
                case "ChromeHTML":
                    return "chrome.exe";
                case "FirefoxURL":
                    return "firefox.exe";
                case "IE.HTTP":
                    return "iexplore.exe";
            }
            return "unknown";
        }
    }
}
