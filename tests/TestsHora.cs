using NUnit.Framework;
using plataforma_automatizada.utils;
using System;

namespace plataforma_automatizada.test
{
    internal class TestsHora : TestBase

    {
        //Declaracion de variables
        String horaEntrada = ParameterReader.GetTestValues("TimePage", "HoraInicio");
        String horaSalida = ParameterReader.GetTestValues("TimePage", "HoraFin");
        String nota = ParameterReader.GetTestValues("TimePage", "Nota");
        String proyecto = ParameterReader.GetTestValues("TimePage", "Proyecto");
        String totalHoras = ParameterReader.GetTestValues("TimePage", "Duracion");
        String totalHSemana = ParameterReader.GetTestValues("TimePage", "TotalHSemana");
        String totalHDia = ParameterReader.GetTestValues("TimePage", "TotalHDia");
        String semanaE = ParameterReader.GetTestValues("TimePage", "SemanaE");
        String diaE = ParameterReader.GetTestValues("TimePage", "DiaE");

        [Description("Agregar hora en proyecto TATF202205")]
        [Test]
        public void AgregarHoraProyecto()
        {
            // Entrada de tiempo en el formulario
            timePage.LlenarFormularioDeEntradaDeHora(horaEntrada, horaSalida, nota);

            // Verificar hora ingresada correctamente
            timePage.VerificarEntradaHora(proyecto, horaEntrada, horaSalida, totalHoras, nota, totalHSemana, totalHDia);

            // Limpiar el registro de hora
            timePage.borrarRegistro(proyecto, horaEntrada, horaSalida, totalHoras, nota);
        }

        [Description("Eliminar hora de proyecto TATF - 202205")]
        [Test]
        public void EliminarHoraDeProyecto()
        {
            // Entrada de tiempo en el formulario
            timePage.LlenarFormularioDeEntradaDeHora(horaEntrada, horaSalida, nota);

            // Verificar el registro ingresado
            timePage.VerificarEntradaHora(proyecto, horaEntrada, horaSalida, totalHoras, nota, totalHSemana, totalHDia);

            // Eliminar Hora 
            timePage.borrarRegistro(proyecto, horaEntrada, horaSalida, totalHoras, nota);


            // Verificar que el record fue eliminado
            timePage.VerificarRegistroBorrado(semanaE, diaE);
        }
    }
}
