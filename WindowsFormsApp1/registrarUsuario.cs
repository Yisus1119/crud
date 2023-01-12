using System;
using System.Windows.Forms;
using CapaNegocio;

namespace WindowsFormsApp1
{
    public partial class registrarUsuario : Form
    {

        Usuarios usuarios = new Usuarios();

        public registrarUsuario()
        {
            InitializeComponent();
        }

        private void limpiarCampos()
        {
            txtCedula.ResetText();
            txtNombre.ResetText();
            txtApellido.ResetText();
            txtTelefono.ResetText();
            txtDireccion.ResetText();
            txtCargo.ResetText();
            txtSueldo.ResetText();
            txtTanda.ResetText();
            txtFecha.ResetText();
            chkAdmin.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                usuarios.InsertarUsuario(Convert.ToInt32(txtCedula.Text), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, txtCargo.Text, txtSueldo.Text,
                    txtTanda.Text, txtFecha.Value, chkAdmin.Checked);
                MessageBox.Show("Se ha registrado el empleado");
                menuPrincipal verInicio = new menuPrincipal();
                verInicio.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido registrar el usuario, error: " + ex);
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("¿Seguro que desea limpiar los campos?", "Limpiarcampos", MessageBoxButtons.YesNo);
            
                if ( (MessageBox.Show("¿Seguro que desea limpiar los campos?", "Limpiar campos",MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                limpiarCampos();
                }
        }

        private void lblVolver_MouseClick(object sender, MouseEventArgs e)
        {
            menuPrincipal verMenuP = new menuPrincipal();
            verMenuP.Show();
            this.Hide();
        }

    }
}
