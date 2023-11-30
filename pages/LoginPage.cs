using OpenQA.Selenium;
using plataforma_automatizada.utils;

namespace plataforma_automatizada.pages
{
    internal class LoginPage : BasePage
    {
        private readonly By usuario;
        private readonly By password;
        private readonly By buttonLogin;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(ParameterReader.GetEnvironmentTracker("UrlEnvironment"));
            usuario = By.Id(ParameterReader.GetScreenComponents("Login", "LoginUser", "TimeComponents.xml"));
            password = By.Id(ParameterReader.GetScreenComponents("Login", "LoginPass", "TimeComponents.xml"));
            buttonLogin = By.Id(ParameterReader.GetScreenComponents("Login", "LoginButton", "TimeComponents.xml"));
        }

        public void IngresarUserName(string text)
        {
            Click(usuario);
            Clear(usuario);
            SendKeys(usuario, text);
        }

        public void IngresarPassName(string text)
        {
            Click(password);
            Clear(password);
            SendKeys(password, text);
        }

        public TimePage ClickLogin(IWebDriver driver)
        {
            Click(buttonLogin);
            return new TimePage(driver);
        }

        public void CerrarNavegador()
        {
            Quit();
        }
    }
}
