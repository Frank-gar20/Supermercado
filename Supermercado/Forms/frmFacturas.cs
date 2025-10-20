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
    public partial class frmFacturas : Form
    {
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select * from facturas order by id");
            DataSet ds2 = datos.getAlldata("select * from facturas_detalles order by id");
            if (ds != null)
            {
                dgvDatos.DataSource = ds.Tables[0];
                dgvDetalles.DataSource = ds2.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmFacturas()
        {
            InitializeComponent();
        }

        private void frmFacturas_Activated(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAlldata("select * from facturas where " +
            "numero ilike '%" + txtBuscar.Text + "%' or " +
            "codigo ilike '%" + txtBuscar.Text + "%' or " +
            "fecha::text ilike '%" + txtBuscar.Text + "%' or " +
            "hora::text ilike '%" + txtBuscar.Text + "%' or " +
            "importe_total::text ilike '%" + txtBuscar.Text + "%'");
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
