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
        int id = -1;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();

            if (id == -1)
            {
                string query = "INSERT INTO empleados (nombre, apellido, edad, fecha_nac, tipo_doc, nro_doc, cuil, direccion, nro_tel_princ, nro_tel_sec, email, cargo, antiguedad, fecha_ingreso, salario_anual) " +
                     "VALUES ('" + txtNombre.Text + "', '" + txtApellido.Text + "', " + txtEdad.Text + ", '" + txtFechaNac.Text + "', '" +
                     txtTipoDoc.Text + "', '" + txtNroDoc.Text + "', '" + txtCuli.Text + "', '" + txtDireccion.Text + "', '" +
                     mtbNroTelPrinc.Text + "', '" + mtbNroTelSec.Text + "', '" + txtEmail.Text + "', '" + txtCargo.Text + "', '" +
                     txtAntiguedad.Text + "', '" + txtFechaIngreso.Text + "', " + txtSalarioAnual.Text + ")";
                resultado = data.ExecuteQuery(query);
                if (resultado)
                {
                    MessageBox.Show("Registro agregado", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al agregar el registro", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string query = "UPDATE empleados SET " +
                     "nombre = '" + txtNombre.Text + "', " +
                     "apellido = '" + txtApellido.Text + "', " +
                     "edad = " + txtEdad.Text + ", " +
                     "fecha_nac = '" + txtFechaNac.Text + "', " +
                     "tipo_doc = '" + txtTipoDoc.Text + "', " +
                     "nro_doc = '" + txtNroDoc.Text + "', " +
                     "cuil = '" + txtCuli.Text + "', " +
                     "direccion = '" + txtDireccion.Text + "', " +
                     "nro_tel_princ = '" + mtbNroTelPrinc.Text + "', " +
                     "nro_tel_sec = '" + mtbNroTelSec.Text + "', " +
                     "email = '" + txtEmail.Text + "', " +
                     "cargo = '" + txtCargo.Text + "', " +
                     "antiguedad = '" + txtAntiguedad.Text + "', " +
                     "fecha_ingreso = '" + txtFechaIngreso.Text + "', " +
                     "salario_anual = " + txtSalarioAnual.Text + " " +
                     "WHERE id = " + id;
                resultado = data.ExecuteQuery(query);
                if (resultado)
                {
                    MessageBox.Show("Registro Acutalizdo", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Actualizar el registro", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dgvDatos[0, dgvDatos.CurrentCell.RowIndex].Value.ToString();
            bool resultado;
            Datos datos = new Datos();
            if (MessageBox.Show("¿estas seguro de Borrar?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string query = "Delete from empleados where id = " + id;
                resultado = datos.ExecuteQuery(query);
                if (resultado)
                {
                    MessageBox.Show("Registro Eliminado", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
