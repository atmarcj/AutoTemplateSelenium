using NUnit.Framework;
using plataforma_automatizada.utils;
using System;

namespace plataforma_automatizada.test
{
    internal class TestsProyecto : TestBase
    {

        [Description("Verificar proyecto TATF - 202205")]
        [Test]
        public void VerificarProyecto()
        {
            //Declaracion de variables
            String proyecto = ParameterReader.GetTestValues("TimePage", "Proyecto");

            //Dirigirse a la pagina Proyectos
            proyectosPage = menu.IrAProyectos();

            //Verificar que el proyecto existe
            Assert.That(proyectosPage.ExisteProyecto(driver, proyecto), Is.True);
        }
    }
}
