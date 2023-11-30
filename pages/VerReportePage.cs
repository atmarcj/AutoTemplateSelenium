using System;
using OpenQA.Selenium;
using plataforma_automatizada.utils;
using System.Collections.Generic;
using NUnit.Framework;

namespace plataforma_automatizada.pages
{
    internal class VerReportePage : BasePage
    {
        private readonly By dateToday;
        private readonly By nombreProyecto;
        private readonly By horaInicio;
        private readonly By horaFin;
        private readonly By totalHorasDia;
        private readonly By nota;
        private readonly By totalReporte;

        public VerReportePage(IWebDriver driver) : base(driver)
        {
            DateTime thisDay = DateTime.Today;
            dateToday = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "Fecha", "TimeComponents.xml"));
            nombreProyecto = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "NombreProyecto", "TimeComponents.xml"));
            horaInicio = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "HoraInicio", "TimeComponents.xml"));
            horaFin = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "HoraFin", "TimeComponents.xml"));
            totalHorasDia = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "TotalDia", "TimeComponents.xml"));
            nota = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "Nota", "TimeComponents.xml"));
            totalReporte = By.CssSelector(ParameterReader.GetScreenComponents("Reportes", "TotalReporte", "TimeComponents.xml"));
        }

        public String ObtenerFechaActual()
        {
            return driver.FindElement(dateToday).Text;
        }

        public String ObtenerNombreProyecto()
        {
            return driver.FindElement(nombreProyecto).Text;
        }

        public String ObtenerHoraInicio()
        {
            return driver.FindElement(horaInicio).Text;
        }

        public String ObtenerHoraFin()
        {
            return driver.FindElement(horaFin).Text;
        }

        public String ObtenerHorasDia()
        {
            return driver.FindElement(totalHorasDia).Text;
        }

        public String ObtenerNota()
        {
            return driver.FindElement(nota).Text;
        }

        public String ObtenerTotalReporte()
        {
            return driver.FindElement(totalReporte).Text;
        }

        public void VerificarReporteGenerado(string proyecto, string horaEntrada, string horaSalida, string duracion, string nota, string horaReporte)
        {
            Assert.That(ObtenerFechaActual(), Is.EqualTo(DateTime.Today.ToString("yyyy-MM-dd")));
            Assert.That(ObtenerNombreProyecto(), Is.EqualTo(proyecto));
            Assert.That(ObtenerHoraInicio(), Is.EqualTo(horaEntrada));
            Assert.That(ObtenerHoraFin(), Is.EqualTo(horaSalida));
            Assert.That(ObtenerHorasDia(), Is.EqualTo(duracion));
            Assert.That(ObtenerNota(), Is.EqualTo(nota));
            Assert.That(ObtenerTotalReporte(), Is.EqualTo(horaReporte));
        }

    }
}
