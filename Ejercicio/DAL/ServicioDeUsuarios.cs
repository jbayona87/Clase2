using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.DAL
{
    public class ServicioDeUsuarios
    {
        private SqlConnection iniciarConexion()
        {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["TIENDA"].ConnectionString;
            return conection;
        }
        public void CrearUsuario(NuevoUsuario Usuario)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("CREARUSUARIO", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Name", Usuario.Name));
            comando.Parameters.Add(new SqlParameter("@Clave", Usuario.Clave));
            comando.Parameters.Add(new SqlParameter("@Enable", Usuario.Enable));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }
        public List<NuevoUsuario> ListarUsuario()
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("LISTARUSUARIO", conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            SqlDataReader lectorDeDatos = comando.ExecuteReader();
            List<NuevoUsuario> usuarios = new List<NuevoUsuario>();
            while (lectorDeDatos.Read())
            {
                NuevoUsuario usuario = new NuevoUsuario();
                usuario.Id = (int)lectorDeDatos.GetInt32(0);
                usuario.Name = lectorDeDatos.GetString(1);
                usuario.Clave = lectorDeDatos.GetString(2);
                usuario.Enable = (Boolean)lectorDeDatos.GetBoolean(3);
                usuarios.Add(usuario);
            }
            conection.Close();
            return usuarios;
        }
        public void EliminarUsuario(int Id)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("ELIMINAR_USUARIO", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }
    }
}
