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
    public partial class frmProveedores : Form
    {
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select * from proveedores order by id");
            if (ds != null)
            {
                dgvDatos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Activated(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAlldata("select * from proveedores where " +
            "empresa ilike '%" + txtBuscar.Text + "%' or " +
            "tipo_producto ilike '%" + txtBuscar.Text + "%' or " +
            "direccion ilike '%" + txtBuscar.Text + "%' or " +
            "nro_tel_princ ilike '%" + txtBuscar.Text + "%' or " +
            "nro_tel_sec ilike '%" + txtBuscar.Text + "%' or " +
            "email ilike '%" + txtBuscar.Text + "%'");
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
