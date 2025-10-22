using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermercado.Forms
{
    public partial class frmVentas : Form
    {
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select * from ventas order by id");
            DataSet ds2 = datos.getAlldata("select * from ventas_productos order by id");
            DataSet ds3 = datos.getAlldata("select * from compras_clientes order by id");
            if (ds != null)
            {
                dgvVentas.DataSource = ds.Tables[0];
                dgvDetalles.DataSource = ds2.Tables[0];
                dgvCompras.DataSource = ds3.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Activated(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
