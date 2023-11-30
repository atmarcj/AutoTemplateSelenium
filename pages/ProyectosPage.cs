using System;
using System.Linq;
using OpenQA.Selenium;
using plataforma_automatizada.utils;

namespace plataforma_automatizada.pages
{
    internal class ProyectosPage : BasePage
    {
        public ProyectosPage(IWebDriver driver) : base(driver)
        {
            if (!driver.Title.Equals("Time Tracker - Proyectos"))
                throw new Exception("Pagina de proyectos no fue cargada correctamente");
        }

        public bool ExisteProyecto(IWebDriver driver, String proy)
        {
            Boolean existe = false;
            int it = 2;
            int rows = driver.FindElements(By.CssSelector("tbody")).Count();
            String locatorStr;
            do
            {
                locatorStr = ParameterReader.GetScreenComponents("Proyectos", "LocatorPartOne", "TimeComponents.xml") + it + ParameterReader.GetScreenComponents("Proyectos", "LocatorPartTwo", "TimeComponents.xml");
                existe = string.Equals(driver.FindElement(By.CssSelector(locatorStr)).Text, proy);
                ++it;
            } while (!existe && it < rows);
            return existe;
        }
    }
}
