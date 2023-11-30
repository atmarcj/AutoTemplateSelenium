using System;
using OpenQA.Selenium;
using plataforma_automatizada.utils;
using System.Collections.Generic;
using NUnit.Framework;

namespace plataforma_automatizada.pages
{
    internal class TimePage : BasePage
    {
        private readonly By todayButton;
        private readonly By proyDropdown;
        private readonly By proyecto;
        private readonly By startDate;
        private readonly By endDate;
        private readonly By note;
        private readonly By botonSubmit;
        private readonly string botonEndPath;
        private readonly string botonInicialPath;

        public TimePage(IWebDriver driver) : base(driver)
        {
            if (!driver.Title.Equals("Time Tracker - Tiempo"))
                throw new Exception("Pagina de Tiempo no fue cargada correctamente");
            todayButton = By.LinkText(ParameterReader.GetScreenComponents("TimeTracker", "TodayBtn", "TimeComponents.xml"));
            proyDropdown = By.Id(ParameterReader.GetScreenComponents("TimeTracker", "DropdownProyectos", "TimeComponents.xml"));
            proyecto = By.XPath(ParameterReader.GetScreenComponents("TimeTracker", "Proyecto", "TimeComponents.xml"));
            startDate = By.Id(ParameterReader.GetScreenComponents("TimeTracker", "HoraInicio", "TimeComponents.xml"));
            endDate = By.Id(ParameterReader.GetScreenComponents("TimeTracker", "HoraFin", "TimeComponents.xml"));
            note = By.Id(ParameterReader.GetScreenComponents("TimeTracker", "Nota", "TimeComponents.xml"));
            botonSubmit = By.Id(ParameterReader.GetScreenComponents("TimeTracker", "BotonSubmit", "TimeComponents.xml"));
            botonInicialPath = ParameterReader.GetScreenComponents("TimeTracker", "BotonInicialPath", "TimeComponents.xml");
            botonEndPath = ParameterReader.GetScreenComponents("TimeTracker", "BotonEndPath", "TimeComponents.xml");
        }

        public void SeleccionarFechaDeHoy()
        {
            Click(todayButton);
        }

        public void SeleccionarProyecto()
        {
            Click(proyDropdown);
            Click(proyecto);
        }

        public void IngresarHoraInicio(String hora)
        {
            Click(startDate);
            SendKeys(startDate, hora);
        }

        public void IngresarHoraFin(String hora)
        {
            Click(endDate);
            SendKeys(endDate, hora);
        }

        public void IngresarNota(String nota)
        {
            Click(note);
            SendKeys(note, nota);
        }

        public TimePage ClickEnviar()
        {
            Click(botonSubmit);
            return this;
        }

        public String ObtenerProyectoEntradaCreada()
        {
            return driver.FindElement(By.CssSelector(ParameterReader.GetScreenComponents("TimeTracker", "ProyectoEntrado", "TimeComponents.xml"))).Text;
        }

        public String ObtenerHoraInicioEntradaCreada()
        {
            return driver.FindElement(By.XPath(ParameterReader.GetScreenComponents("TimeTracker", "HoraInicioEntrada", "TimeComponents.xml"))).Text;
        }

        public String ObtenerHoraFinEntradaCreada()
        {
            return driver.FindElement(By.XPath(ParameterReader.GetScreenComponents("TimeTracker", "HoraFinEntrada", "TimeComponents.xml"))).Text;
        }

        public String ObtenerDuracionEntradaCreada()
        {
            return driver.FindElement(By.XPath(ParameterReader.GetScreenComponents("TimeTracker", "DuracionEntrada", "TimeComponents.xml"))).Text;
        }

        public String ObtenerNotaEntradaCreada()
        {
            return driver.FindElement(By.XPath(ParameterReader.GetScreenComponents("TimeTracker", "NotaEntrada", "TimeComponents.xml"))).Text;
        }

        public String ObtenerTotalHorasSemana()
        {
            return driver.FindElement(By.CssSelector(ParameterReader.GetScreenComponents("TimeTracker", "TotalHorasSemana", "TimeComponents.xml"))).Text;
        }

        public String ObtenerTotalHorasDia()
        {
            return driver.FindElement(By.CssSelector(ParameterReader.GetScreenComponents("TimeTracker", "TotalHoras", "TimeComponents.xml"))).Text;
        }

        public void LlenarFormularioDeEntradaDeHora(string horaEntrada, string horaSalida, string nota)
        {
            SeleccionarFechaDeHoy();
            SeleccionarProyecto();
            IngresarHoraInicio(horaEntrada);
            IngresarHoraFin(horaSalida);
            IngresarNota(nota);
            ClickEnviar();
        }

        public void borrarRegistro(string projecto, string horaEntrada, string horaSalida, string totalHoras, string nota)
        {
            IWebElement tabla = driver.FindElement(By.CssSelector("body > div.page-content > form > div.record-list > table > tbody"));
            IList<IWebElement> filas = tabla.FindElements(By.TagName("tr"));
            String filaHoras = projecto + " " + horaEntrada + " " + horaSalida + " " + totalHoras + " " + nota;
            int i = 0;
            foreach (var item in filas)
            {
                i++;
                if (string.Equals(item.Text, filaHoras))
                {
                    string buttonDeleteXpath = botonInicialPath + i + botonEndPath;
                    driver.FindElement(By.XPath(buttonDeleteXpath)).Click();
                    Click(By.Id(ParameterReader.GetScreenComponents("TimeTracker", "BotonConfirmarEl", "TimeComponents.xml")));
                    break;
                }
            }
        }

        public void VerificarRegistroBorrado(string semanaE, string diaE)
        {
            SeleccionarFechaDeHoy();
            Assert.That(ObtenerTotalHorasSemana(), Is.EqualTo("Week total: " + semanaE));
            Assert.That(ObtenerTotalHorasDia(), Is.EqualTo("Day total: " + diaE));
        }

        public void VerificarEntradaHora (string proyecto, string horaEntrada, string horaSalida, string totalHoras, string nota, string totalHSemana, string totalHDia)
        {
            Assert.That(ObtenerProyectoEntradaCreada(), Is.EqualTo(proyecto));
            Assert.That(ObtenerHoraInicioEntradaCreada(), Is.EqualTo(horaEntrada));
            Assert.That(ObtenerHoraFinEntradaCreada(), Is.EqualTo(horaSalida));
            Assert.That(ObtenerDuracionEntradaCreada(), Is.EqualTo(totalHoras));
            Assert.That(ObtenerNotaEntradaCreada(), Is.EqualTo(nota));
            Assert.That(ObtenerTotalHorasSemana(), Is.EqualTo("Week total: " + totalHSemana));
            Assert.That(ObtenerTotalHorasDia(), Is.EqualTo("Day total: " + totalHDia));
        }
    }
}
