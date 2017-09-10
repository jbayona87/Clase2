using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Ejercicio.DAL;

namespace Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioDeUsuarios servicioUsuario = new ServicioDeUsuarios();
            NuevoUsuario nuevoUsuario = new NuevoUsuario();
            nuevoUsuario.Name = "VICTOR";
            nuevoUsuario.Clave = "12345";
            nuevoUsuario.Enable = true;
            servicioUsuario.CrearUsuario(nuevoUsuario);

          
            servicioUsuario.EliminarUsuario(2);

            servicioUsuario.ListarUsuario().ForEach(usuario => Console.WriteLine(usuario.Name));
            Console.ReadKey();
        }
    }
}
