using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class claseConexion
    {
        private SqlConnection conn = new SqlConnection("Server=(local);DataBase= tienda;Integrated Security=true");

        public SqlConnection abrirConexion()
        {
            if(conn.State==ConnectionState.Closed)
                conn.Open();
            return conn;
        }

        public SqlConnection cerrarConexion()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }




    }
}
