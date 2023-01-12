using System;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Usuarios
    {
        private claseUsuarios objetoUsuarios = new claseUsuarios();

        public DataTable mostrarUsuarios()
        {
            DataTable dt = new DataTable();
            dt = objetoUsuarios.mostrarUsuario();
            return dt;
        }

        public void InsertarUsuario(int cedula, String nombre, String apellido, String telefono, String direccion, String cargo, String sueldo, String tanda,
          DateTime fechaContratacion, bool isAdmin)
        {
            objetoUsuarios.Insertar(Convert.ToInt32(cedula),nombre,apellido, telefono, direccion, cargo, sueldo, tanda, fechaContratacion, isAdmin);
        }

        
        public DataTable buscarUsuario(int cedula)
        {

            DataTable dt = new DataTable();
            dt = objetoUsuarios.buscarEmpleado(Convert.ToInt32(cedula));
            return dt;
        }
        public void editarUsuario(int cedula, String nombre, String apellido, String telefono, String direccion, String cargo, String sueldo, String tanda,
          DateTime fechaContratacion, bool isAdmin)
        {
            objetoUsuarios.Editar(Convert.ToInt32(cedula),nombre,apellido,telefono, direccion, cargo, sueldo,tanda, fechaContratacion, isAdmin);
        }

        public void eliminarUsuario(int cedula)
        {
            objetoUsuarios.Eliminar(Convert.ToInt32(cedula));
        }

    }
}
