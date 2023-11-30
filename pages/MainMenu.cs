using OpenQA.Selenium;
using plataforma_automatizada.utils;

namespace plataforma_automatizada.pages
{
    internal class MainMenu : BasePage
    {
        private readonly By logoutButton;
        private readonly By reportsButton;
        private readonly By personsButton;
        private readonly By proyectsButton;
        private readonly By timeTrackerButton;

        public MainMenu(IWebDriver driver) : base(driver)
        {
            logoutButton = By.LinkText(ParameterReader.GetScreenComponents("Header", "LogoutBtn", "TimeComponents.xml"));
            reportsButton = By.LinkText(ParameterReader.GetScreenComponents("Header", "ReportsBtn", "TimeComponents.xml"));
            personsButton = By.LinkText(ParameterReader.GetScreenComponents("Header", "PersonsBtn", "TimeComponents.xml"));
            proyectsButton = By.LinkText(ParameterReader.GetScreenComponents("Header", "ProyectsBtn", "TimeComponents.xml"));
            timeTrackerButton = By.LinkText(ParameterReader.GetScreenComponents("Header", "TimeTrackerBtn", "TimeComponents.xml"));
        }

        public GenerarReporte IrAReportes()
        {
            Click(reportsButton);
            return new GenerarReporte(driver);
        }

        public TimePage IrATimeTracker()
        {
            Click(timeTrackerButton);
            return new TimePage(driver);
        }

        public PersonasPage IrAPersonas()
        {
            Click(personsButton);
            return new PersonasPage(driver);
        }

        public ProyectosPage IrAProyectos()
        {
            Click(proyectsButton);
            return new ProyectosPage(driver);
        }

        public void Logout()
        {
            Click(logoutButton);
        }
    }
}
