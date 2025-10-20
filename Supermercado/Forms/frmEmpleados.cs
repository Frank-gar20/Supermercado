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
    public partial class frmEmpleados : Form
    {
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select * from empleados order by id");
            if (ds != null)
            {
                dgvDatos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Activated(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAlldata("select * from empleados where " +
            "nombre ilike '%" + txtBuscar.Text + "%' or " +
            "apellido ilike '%" + txtBuscar.Text + "%' or " +
            "edad::text ilike '%" + txtBuscar.Text + "%' or " +
            "fecha_nac::text ilike '%" + txtBuscar.Text + "%' or " +
            "tipo_doc ilike '%" + txtBuscar.Text + "%' or " +
            "nro_doc ilike '%" + txtBuscar.Text + "%' or " +
            "cuil ilike '%" + txtBuscar.Text + "%' or " +
            "direccion ilike '%" + txtBuscar.Text + "%' or " +
            "nro_tel_princ ilike '%" + txtBuscar.Text + "%' or " +
            "nro_tel_sec ilike '%" + txtBuscar.Text + "%' or " +
            "email ilike '%" + txtBuscar.Text + "%' or " +
            "cargo ilike '%" + txtBuscar.Text + "%' or " +
            "antiguedad ilike '%" + txtBuscar.Text + "%' or " +
            "fecha_ingreso::text ilike '%" + txtBuscar.Text + "%' or " +
            "salario_anual::text ilike '%" + txtBuscar.Text + "%'");
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
