using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;

namespace Selenium.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string pathDriver = null)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    var service = FirefoxDriverService.CreateDefaultService(
                                   pathDriver);
                    webDriver = new FirefoxDriver(service);
                    break;
                case Browser.Chrome:
                    webDriver = new ChromeDriver(pathDriver);
                    break;
                case Browser.InternetExplorer:
                    webDriver = new InternetExplorerDriver(pathDriver);
                    break;
                case Browser.Edge:
                    webDriver = new EdgeDriver(pathDriver);
                    break;
            }

            return webDriver;
        }
    }
}
