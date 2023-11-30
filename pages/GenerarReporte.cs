using OpenQA.Selenium;
using plataforma_automatizada.utils;
using System;

namespace plataforma_automatizada.pages
{
    internal class GenerarReporte : BasePage
    {
        private readonly By timePeriodDropdown;
        private readonly By todayOptDropdown;
        private readonly By projectsDropdown;
        private readonly By projectsItem1;
        private readonly By projectsItem2;
        private readonly By generateButton;

        public GenerarReporte(IWebDriver driver) : base(driver)
        {
            if (!driver.Title.Equals("Time Tracker - Reportes"))
                throw new Exception("Pagina de Reportes no fue cargada correctamente");
            timePeriodDropdown = By.Id(ParameterReader.GetScreenComponents("Reportes", "PeriodDropdown", "TimeComponents.xml"));
            todayOptDropdown = By.XPath(ParameterReader.GetScreenComponents("Reportes", "PeriodOptHoy", "TimeComponents.xml"));
            projectsDropdown = By.Id(ParameterReader.GetScreenComponents("Reportes", "ProyectsDropdown", "TimeComponents.xml"));
            projectsItem1 = By.XPath(ParameterReader.GetScreenComponents("Reportes", "ProyectTATFitem1", "TimeComponents.xml"));
            projectsItem2 = By.XPath(ParameterReader.GetScreenComponents("Reportes", "ProyectTATFitem2", "TimeComponents.xml"));
            generateButton = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "GenerateButton", "TimeComponents.xml"));
        }

        public void seleccionarPeriodoHoy()
        {
            Click(timePeriodDropdown);
            Click(todayOptDropdown);
        }

        public void seleccionarProyecto(String proyecto)
        {
            Click(projectsDropdown);

            switch (proyecto)
            {
                case "IATF-202205":
                    Click(projectsItem2);

                    break;
                case "TATF-202205":
                    Click(projectsItem1);
                    break;
                default:
                    Click(projectsItem2);
                    break;
            }
        }

        public VerReportePage generarReporte()
        {
            Click(generateButton);
            return new VerReportePage(driver);
        }

    }
}
