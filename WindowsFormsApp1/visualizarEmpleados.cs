using System;
using System.Windows.Forms;
using CapaNegocio;

namespace WindowsFormsApp1
{
    public partial class visualizarEmpleados : Form
    {
        Usuarios usuarios = new Usuarios();


        public visualizarEmpleados()
        {
            InitializeComponent();
        }

        public void buscarUsuario()
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios usr = new Usuarios();
                dataGridView1.DataSource = usr.buscarUsuario(Convert.ToInt32(txtBuscar.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Debe insertar una cedula");
            }
        }

        private void visualizarEmpleados_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }

        private void mostrarUsuarios()
        {
            Usuarios usr = new Usuarios();
            dataGridView1.DataSource = usr.mostrarUsuarios();
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            menuPrincipal verInicio = new menuPrincipal();
            verInicio.Show();
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
            /*
            
            conexion.Open();
        SqlCommand comando = conexion.CreateCommand();

            comando.CommandType = CommandType.Text;
            comando.CommandText = " SELECT * FROM empleado WHERE cedula like ('" + txtBuscar.Text + "%')";
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            dataGridView1.DataSource = dt;
            conexion.Close();
            */

            
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            mostrarUsuarios();
            txtBuscar.ResetText();
        }
    }
}