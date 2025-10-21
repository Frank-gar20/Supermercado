using Supermercado.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermercado
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Timhora_Tick(object sender, EventArgs e)
        {
            LabHora.Text = DateTime.Now.ToString();
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados frmEmpleados = new frmEmpleados();
            frmEmpleados.Show();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frmProductos = new frmProductos();
            frmProductos.Show();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frmProveedores = new frmProveedores();
            frmProveedores.Show();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            frmVentas frmVentas = new frmVentas();
            frmVentas.Show();
        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            frmFacturas frmFacturas = new frmFacturas();
            frmFacturas.Show();
        }
    }
}
