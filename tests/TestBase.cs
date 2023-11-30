using NUnit.Framework;
using OpenQA.Selenium;
using plataforma_automatizada.pages;
using plataforma_automatizada.utils;
using System;

namespace plataforma_automatizada.test
{
    class TestBase
    {
        protected static IWebDriver driver;
        protected LoginPage login;
        protected TimePage timePage;
        protected MainMenu menu;
        protected GenerarReporte generarReporte;
        protected VerReportePage verReporte;
        protected ProyectosPage proyectosPage;
        protected PersonasPage personasPage;

        [SetUp]
        public void AntesDeCadaTest()
        {
            String userName = ParameterReader.GetTestValues("Usuarios", "UserID");
            String userPassword = ParameterReader.GetTestValues("Usuarios", "UserPass");

            driver = Utils.DriverConfiguration();
            login = new LoginPage(driver);
            menu = new MainMenu(driver);
            login.IngresarUserName(userName);
            login.IngresarPassName(userPassword);
            timePage = login.ClickLogin(driver);
        }

        [TearDown]
        public void DespuesDeCadaTest()
        {
            menu.Logout();
            login.CerrarNavegador();
        }
    }
}
