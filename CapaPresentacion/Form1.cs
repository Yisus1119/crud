using CapaNegocio;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        Usuarios objUsuarios = new Usuarios();

        public Form1()
        {
            InitializeComponent();
        }

        public void limpiarCampos()
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
            chkAdmin.ResetText();

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            try
            {
                objUsuarios.InsertarUsuario(txtCedula.TextLength, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, txtCargo.Text, txtSueldo.Text,
                    txtTanda.Text, txtFecha.Value, chkAdmin.Checked);
                MessageBox.Show("Se ha registrado el empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido registrar el usuario, error: " + ex);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Seguro que desea limpiar los campos?", "Confirmar borrado", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                limpiarCampos();

            }
        }
    }
}