using System;
using NUnit.Framework;
using plataforma_automatizada.utils;

namespace plataforma_automatizada.test
{
    internal class TestsReport : TestBase
    {
        [Description("Test: Generar reporte para proyecto TATF - 202205")]
        [Test]
        public void GenerarReporte()
        {
            //Declaracion de variables
            String horaEntrada = ParameterReader.GetTestValues("TimePage", "HoraInicio");
            String horaSalida = ParameterReader.GetTestValues("TimePage", "HoraFin");
            String nota = ParameterReader.GetTestValues("TimePage", "Nota");
            String proyecto = ParameterReader.GetTestValues("TimePage", "Proyecto");
            String duracion = ParameterReader.GetTestValues("TimePage", "Duracion");
            String horaReporte = ParameterReader.GetTestValues("ReportPage", "TotalH");

            // Entrada de tiempo en el formulario
            timePage.LlenarFormularioDeEntradaDeHora(horaEntrada, horaSalida, nota);

            // Generar Reporte 

            generarReporte = menu.IrAReportes();
            generarReporte.seleccionarPeriodoHoy();
            generarReporte.seleccionarProyecto(proyecto);
            verReporte = generarReporte.generarReporte();

            //Verificar reporte
            verReporte.VerificarReporteGenerado(proyecto,  horaEntrada,  horaSalida,  duracion, nota, horaReporte);

            timePage = menu.IrATimeTracker();
            timePage.borrarRegistro(proyecto, horaEntrada, horaSalida, duracion, nota);
        }
    }
}
