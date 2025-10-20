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
    public partial class frmProductos : Form
    {
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select * from productos order by id");
            if (ds != null)
            {
                dgvDatos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Activated(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAlldata("select * from productos where " +
            "CAST(id_proveedor AS text) ilike '%" + txtBuscar.Text + "%' or " +
            "codigo ilike '%" + txtBuscar.Text + "%' or " +
            "imagen ilike '%" + txtBuscar.Text + "%' or " +
            "nombre ilike '%" + txtBuscar.Text + "%' or " +
            "marca ilike '%" + txtBuscar.Text + "%' or " +
            "tipo ilike '%" + txtBuscar.Text + "%' or " +
            "grupo ilike '%" + txtBuscar.Text + "%' or " +
            "peso::text ilike '%" + txtBuscar.Text + "%' or " +
            "precio_unidad::text ilike '%" + txtBuscar.Text + "%' or " +
            "stock::text ilike '%" + txtBuscar.Text + "%'");
            if (ds != null)
            {
                dgvDatos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
