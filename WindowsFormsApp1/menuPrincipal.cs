using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class menuPrincipal : Form
    {
        public menuPrincipal()
        {
            InitializeComponent();
        }

        private void btnRegEmp_Click(object sender, EventArgs e)
        {
            registrarUsuario formRegistrar = new registrarUsuario();
            formRegistrar.Show();
            this.Hide();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            visualizarEmpleados verEmpleados = new visualizarEmpleados();
            verEmpleados.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            administrarEmpleados verAdmin = new administrarEmpleados();
            verAdmin.Show();
            this.Hide();
        }
    }
}
