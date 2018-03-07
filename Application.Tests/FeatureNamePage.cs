using System;
using Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
namespace Application.Tests
{
    public class FeatureNamePage
    {
        private Browser _browser;
        private IWebDriver _driver;

        public FeatureNamePage(Browser browser)
        {
            _browser = browser;

            string driverPath = null;
            switch (browser)
            {
                case Browser.Firefox:
                    driverPath = ConfigurationSettings.AppSettings["FirefoxDriverPath"];
                    break;
                case Browser.Chrome:
                    driverPath = ConfigurationSettings.AppSettings["ChromeDriverPath"];
                    break;
                case Browser.Edge:
                    driverPath = ConfigurationSettings.AppSettings["EdgeDriverPath"];
                    break;
                case Browser.InternetExplorer:
                    driverPath = ConfigurationSettings.AppSettings["InternetExplorerDriverPath"];
                    break;
            }
            _driver = WebDriverFactory.CreateWebDriver(_browser, driverPath);

        }
        public void LoadPage()
        {
            _driver.LoadPage(TimeSpan.FromSeconds(10),
                ConfigurationSettings.AppSettings["SiteUrl"]);
        }

        public void FillValue(string valor)
        {
            _driver.SetText(By.Id("lst-ib"), valor.ToString());
        }

        public void ProcessCalculation()
        {
            _driver.Submit(By.Name("btnK"));

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("cwos")) != null);
        }

        public decimal GetResult()
        {
            return Convert.ToDecimal(
                _driver.GetText(By.Id("cwos")));
        }

        public void Close()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
