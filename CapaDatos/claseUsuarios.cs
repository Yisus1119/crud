using System;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class claseUsuarios
    {
        private claseConexion conectar = new claseConexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand command = new SqlCommand();

        
        public DataTable mostrarUsuario()
        {
            command.Connection = conectar.abrirConexion();
            command.CommandText = "visualizarUsuario";
            command.CommandType = CommandType.StoredProcedure;

            leer = command.ExecuteReader();
            tabla.Load(leer);
            command.Connection = conectar.cerrarConexion();
            return tabla;
        }

      public void Insertar(int cedula, String nombre, String apellido, String telefono, String direccion, String cargo, String sueldo, String tanda, 
          DateTime fechaContratacion, bool isAdmin)
        {
            command.Connection = conectar.abrirConexion();
            command.CommandText = "insertarUsuario";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cedula",cedula);
            command.Parameters.AddWithValue("@nombreEmpleado",nombre);
            command.Parameters.AddWithValue("@apellidoEmpleado",apellido);
            command.Parameters.AddWithValue("@telefonoEmpleado",telefono);
            command.Parameters.AddWithValue("@direccionEmpleado",direccion);
            command.Parameters.AddWithValue("@cargo",cargo);
            command.Parameters.AddWithValue("@sueldo",sueldo);
            command.Parameters.AddWithValue("@tanda",tanda);
            command.Parameters.AddWithValue("@fechaContratacion", fechaContratacion);
            command.Parameters.AddWithValue("@isAdmin",isAdmin);
        
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            command.Connection.Close();
        }

        
        public DataTable buscarEmpleado(int cedula)
        {
            command.Connection = conectar.abrirConexion();
            command.CommandText = "buscarEmpleado";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cedula", cedula);

           leer = command.ExecuteReader();
            tabla.Load(leer);
            command.Connection = conectar.cerrarConexion();
            return tabla;
        }
        

        public void Editar(int cedula, String nombre, String apellido, String telefono, String direccion, String cargo, String sueldo, String tanda,
          DateTime fechaContratacion, bool isAdmin)
        {
            command.Connection = conectar.abrirConexion();
            command.CommandText = "editarUsuario";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@cedula", cedula);
            command.Parameters.AddWithValue("@nombreEmpleado", nombre);
            command.Parameters.AddWithValue("@apellidoEmpleado", apellido);
            command.Parameters.AddWithValue("@telefonoEmpleado", telefono);
            command.Parameters.AddWithValue("@direccionEmpleado", direccion);
            command.Parameters.AddWithValue("@cargo", cargo);
            command.Parameters.AddWithValue("@sueldo", sueldo);
            command.Parameters.AddWithValue("@tanda", tanda);
            command.Parameters.AddWithValue("@fechaContratacion", fechaContratacion);
            command.Parameters.AddWithValue("@isAdmin", isAdmin);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            command.Connection.Close();
        }

        public void Eliminar(int cedula)
        {
            command.Connection = conectar.abrirConexion();
            command.CommandText = "eliminarUsuario";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cedula", cedula);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            command.Connection.Close();
        }

    }

 }

