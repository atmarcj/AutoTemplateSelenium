using NUnit.Framework;
using plataforma_automatizada.utils;
using System;

namespace plataforma_automatizada.test
{
    internal class TestsPersonas : TestBase
    {
        [Description("Verificar usuario en lista de Usuarios")]
        [Test]
        public void ValidarUsuarioEnListaDeUsuarios()
        {
            //Declaracion de variables
            String username = ParameterReader.GetTestValues("Usuarios", "UserID");
            String completeName = ParameterReader.GetTestValues("Usuarios", "NombreUsuario");
            String rol = ParameterReader.GetTestValues("Usuarios", "Rol");

            //Dirigirse a la pagina Personas
            personasPage = menu.IrAPersonas();

            // Verificar que el usuario en la pagina
            personasPage.VerificarUsuarioEstaPresente(driver, completeName, username, rol);
        }
    }
}
