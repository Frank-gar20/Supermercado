using ImageMagick;
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
    public partial class frmClientes : Form
    {
        int id = -1;
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select * from clientes order by id");
            if (ds != null)
            {
                dgvDatos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmClientes()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmClientes_Activated(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAlldata("select * from clientes where " +
                "nombre ilike '%" + txtBuscar.Text+"%' or "+
                "apellido ilike '%"+ txtBuscar.Text+"%' or "+
                "tipo_doc ilike '%"+ txtBuscar.Text+"%' or "+
                "nro_doc ilike '%"+ txtBuscar.Text+"%' or "+
                "nro_tel_princ ilike '%" + txtBuscar.Text+"%' or "+
                "nro_tel_sec ilike '%" + txtBuscar.Text+"%' or "+
                "email ilike '%"+ txtBuscar.Text+"%'");
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
                string query = "INSERT INTO clientes (nombre, apellido, tipo_doc, nro_doc, nro_tel_princ, nro_tel_sec, email) " +
                     "VALUES ('" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtTipoDoc.Text + "', '" +
                     txtNroDoc.Text + "', '" + mtbNroTelPrinc.Text + "', '" + mtbNroTelSec.Text + "', '" + txtEmail.Text + "')";

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
                string query = "UPDATE clientes SET " +
                     "nombre = '" + txtNombre.Text + "', " +
                     "apellido = '" + txtApellido.Text + "', " +
                     "tipo_doc = '" + txtTipoDoc.Text + "', " +
                     "nro_doc = '" + txtNroDoc.Text + "', " +
                     "nro_tel_princ = '" + mtbNroTelPrinc.Text + "', " +
                     "nro_tel_sec = '" + mtbNroTelSec.Text + "', " +
                     "email = '" + txtEmail.Text + "' " +
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
    }
}
