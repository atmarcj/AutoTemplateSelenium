using System;
using NUnit.Framework;
using OpenQA.Selenium;
using plataforma_automatizada.utils;
using System.Collections.Generic;

namespace plataforma_automatizada.pages
{
    internal class PersonasPage : BasePage
    {
        public PersonasPage(IWebDriver driver) : base(driver)
        {
            if (!driver.Title.Equals("Time Tracker - Personas"))
                throw new Exception("Pagina de Personas no fue cargada correctamente");
        }

        public void VerificarUsuarioEstaPresente(IWebDriver driver, String nombreUsuario, string userId, string usuarioRol)
        {
            IWebElement tabla = driver.FindElement(By.CssSelector(ParameterReader.GetScreenComponents("Personas", "TablaPersonas", "TimeComponents.xml")));
            IList<IWebElement> filas = tabla.FindElements(By.TagName(ParameterReader.GetScreenComponents("Personas", "TablaTr", "TimeComponents.xml")));
            Boolean existe = false;
            String infoUsuario = nombreUsuario + " " + userId + " " + usuarioRol;
            foreach (var item in filas)
            {
                if (string.Equals(item.Text, infoUsuario))
                {
                    existe = true;
                    break;
                }
            }
            Assert.That(existe, Is.EqualTo(true));
        }
    }
}
