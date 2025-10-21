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
    public partial class frmProductos : Form
    {
        int id = -1;
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select id, id_proveedor, codigo, nombre, marca, tipo, grupo," +
                "peso, precio_unidad, stock from productos order by id");
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();

            if (id == -1)
            {
                string query = "INSERT INTO productos (id_proveedor, codigo, nombre, marca, tipo, grupo, peso, precio_unidad, stock) " +
                     "VALUES (" + txtIdProveedor.Text + ", '" + txtCodigo.Text + "', '" + txtNombre.Text + "', '" +
                     txtMarca.Text + "', '" + txtTipo.Text + "', '" + txtGrupo.Text + "', " + txtPeso.Text + ", " +
                     txtPrecioUnidad.Text + ", " + txtStock.Text + ")";
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
                string query = "UPDATE productos SET " +
                     "id_proveedor = " + txtIdProveedor.Text + ", " +
                     "codigo = '" + txtCodigo.Text + "', " +
                     "nombre = '" + txtNombre.Text + "', " +
                     "marca = '" + txtMarca.Text + "', " +
                     "tipo = '" + txtTipo.Text + "', " +
                     "grupo = '" + txtGrupo.Text + "', " +
                     "peso = " + txtPeso.Text + ", " +
                     "precio_unidad = " + txtPrecioUnidad.Text + ", " +
                     "stock = " + txtStock.Text + " " +
                     "WHERE id = " + id;
                ;
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
                string query = "Delete from productos where id = " + id;
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
