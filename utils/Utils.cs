using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace plataforma_automatizada.utils
{
    /// <summary>
    /// Contiene metodos para auxiliar a las pruebas.
    /// </summary>
    class Utils
    {
        /// <summary>
        /// Configura y retorna un IWebDriver.
        /// </summary>
        /// <returns>Driver configurado.</returns>
        public static IWebDriver DriverConfiguration()
        {
            String browser;
            browser = ParameterReader.GetEnvironmentTracker("Browser");
            ChromeOptions options1;
            IWebDriver driverRetorno;
            FirefoxOptions options2;

            switch (browser)
            {
                case "Chrome":
                    options1 = new ChromeOptions();
                    options1.AddArguments("start-maximized");
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driverRetorno = new ChromeDriver(options1);
                    driverRetorno.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    return driverRetorno;
                case "Firefox":
                    options2 = new FirefoxOptions();
                    options2.BrowserExecutableLocation = ParameterReader.GetEnvironmentTracker("FirefoxLocation");
                    driverRetorno = new FirefoxDriver(options2);
                    return driverRetorno;
                default:
                    options1 = new ChromeOptions();
                    options1.AddArguments("start-maximized");
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driverRetorno = new ChromeDriver(options1);
                    driverRetorno.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    return driverRetorno;
            }
        }
    }
}