using System;
using System.Windows.Forms;
using CapaNegocio;

namespace WindowsFormsApp1
{
    public partial class administrarEmpleados : Form
    {
        Usuarios usuarios = new Usuarios();
       // private string cedulaUsuario = null;
        private bool Editar = false;
        private bool condicion = false;

        public administrarEmpleados()
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
            fechaPicker.ResetText();
            chkAdmin.Checked = false;
        }

        private void administrarEmpleados_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }

        private void mostrarUsuarios()
        {
            Usuarios usr = new Usuarios();
            dataGridView1.DataSource = usr.mostrarUsuarios();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            condicion = true;
            if (Editar == false)
            {
                try
                {
                    if (condicion == true)
                    {
                        usuarios.InsertarUsuario(Convert.ToInt32(txtCedula.Text), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, txtCargo.Text, txtSueldo.Text,
                         txtTanda.Text, fechaPicker.Value, chkAdmin.Checked);
                        MessageBox.Show("Se ha registrado el empleado");
                        mostrarUsuarios();
                        limpiarCampos();
                    }else
                    {

                    }
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("No se ha podido registrar el usuario, error: " + ex);
                    MessageBox.Show("Debe llenar los campos para poder ingresar un registro");
                }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios usr = new Usuarios();
                dataGridView1.DataSource = usr.buscarUsuario(Convert.ToInt32(txtCedula.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe insertar una cedula");
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            mostrarUsuarios();
            txtCedula.ResetText();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                condicion = true;
            try
            {
                if (condicion == true)
                {
                    usuarios.editarUsuario(Convert.ToInt32(txtCedula.Text), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, txtCargo.Text, txtSueldo.Text,
                        txtTanda.Text, fechaPicker.Value, chkAdmin.Checked);
                    MessageBox.Show("se edito correctamente");
                    mostrarUsuarios();
                    limpiarCampos();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No se ha podido registrar el usuario, error: " + ex);
                MessageBox.Show("Debe seleccionar una cedula para poder editar");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCedula.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombreEmpleado"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["apellidoEmpleado"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefonoEmpleado"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["direccionEmpleado"].Value.ToString();
                txtCargo.Text = dataGridView1.CurrentRow.Cells["cargo"].Value.ToString();
                txtSueldo.Text = dataGridView1.CurrentRow.Cells["sueldo"].Value.ToString();
                txtTanda.Text = dataGridView1.CurrentRow.Cells["tanda"].Value.ToString();
                fechaPicker.Value = (DateTime)dataGridView1.CurrentRow.Cells["fechaContratacion"].Value;
                chkAdmin.Enabled = (bool)dataGridView1.CurrentRow.Cells["isAdmin"].Value;

            }
            catch (Exception ex)
            {

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
            var confirmar = MessageBox.Show("¿Está seguro que desea borrar al usuario seleccionado?", "Confirmar eliminacion", MessageBoxButtons.YesNo);
                if(confirmar == DialogResult.Yes)
                {
                usuarios.eliminarUsuario(Convert.ToInt32(txtCedula.Text));
                    MessageBox.Show("Se ha borrado el usuario seleccionado.");
                    mostrarUsuarios();
                    limpiarCampos();
                }
                else
                {

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Debe seleccionar la cedula del usuario que desea eliminar "+ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            menuPrincipal verMenu = new menuPrincipal();
            verMenu.Show();
            this.Hide();
        }
    }
}
