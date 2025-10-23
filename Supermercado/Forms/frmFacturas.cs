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
        int idFacturas = -1;
        Datos datos = new Datos();
        private void mostrarDatos()
        {
            DataSet ds = datos.getAlldata("select * from facturas order by id");
            DataSet ds2 = datos.getAlldata("select * from facturas_detalles order by id");
            if (ds != null)
            {
                dgvDatosFacturas.DataSource = ds.Tables[0];
                dgvDatosDetalles.DataSource = ds2.Tables[0];
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
        private void CargarDatosFacturas(int id)
        {
            DataSet ds = datos.getAlldata("SELECT * FROM facturas WHERE id = " + id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtNumero.Text = ds.Tables[0].Rows[0]["numero"].ToString();
                txtCodigo.Text = ds.Tables[0].Rows[0]["codigo"].ToString();
                txtImporte.Text = ds.Tables[0].Rows[0]["importe_total"].ToString();
                mktHora.Text = ds.Tables[0].Rows[0]["hora"].ToString();
                dtpFecha.Text = ds.Tables[0].Rows[0]["fecha"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontró la factura", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                dgvDatosFacturas.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ELIMINAR FACTURAS
            string id = dgvDatosFacturas[0, dgvDatosFacturas.CurrentCell.RowIndex].Value.ToString();
            bool resultado;
            Datos datos = new Datos();
            if (MessageBox.Show("¿estas seguro de Borrar?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string query = "Delete from facturas where id = " + id;
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

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EDITAR FACTURAS
            if (dgvDatosFacturas.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvDatosFacturas[0, dgvDatosFacturas.CurrentCell.RowIndex].Value);
                CargarDatosFacturas(id);
                btnAgregarFacturas.Text = "Actualizar";
                this.idFacturas = id;
            }
        }

        private void btnAgregarFacturas_Click(object sender, EventArgs e)
        {
            bool resultado;
            Datos data = new Datos();

            if (idFacturas == -1)
            {
                string query = "INSERT INTO facturas (numero, codigo, fecha, hora, importe_total) " +
                     "VALUES ('" + txtNumero.Text + "', "+
                     "'"+txtCodigo.Text+"', "+
                     "'" + dtpFecha.Value.ToString("yyyy-MM-dd")+"', "+
                     "'" + mktHora.Text + "', "+
                     Convert.ToDecimal(txtImporte.Text)+ ")";

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
                string query = "UPDATE facturas SET " +
                     "codigo = '" + txtCodigo.Text + "', " +
                     "fecha = '" + dtpFecha.Value.ToString("yyyy-MM-dd") + "', " +
                     "hora = '" + mktHora.Text + "', " +
                     "importe_total = " + Convert.ToDecimal(txtImporte.Text) + " " +
                     "WHERE id = " + idFacturas;
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

        private void txtBuscarDetalles_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = datos.getAlldata("SELECT * FROM facturas_detalles WHERE " +
            "CAST(id AS TEXT) ILIKE '%" + txtBuscarDetalles.Text + "%' OR " +
            "CAST(id_factura AS TEXT) ILIKE '%" + txtBuscarDetalles.Text + "%' OR " +
            "CAST(tipo AS TEXT) ILIKE '%" + txtBuscarDetalles.Text + "%' OR " +
            "descr_factura ILIKE '%" + txtBuscarDetalles.Text + "%' OR " +
            "CAST(costo_asoc AS TEXT) ILIKE '%" + txtBuscarDetalles.Text + "%' OR " +
            "CAST(iva AS TEXT) ILIKE '%" + txtBuscarDetalles.Text + "%' OR " +
            "CAST(medio_de_pago AS TEXT) ILIKE '%" + txtBuscarDetalles.Text + "%' OR " +
            "descr_pago ILIKE '%" + txtBuscarDetalles.Text + "%';");

            if (ds != null)
            {
                dgvDatosDetalles.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //ELIMINAR DETALLES
            string id = dgvDatosDetalles[0, dgvDatosDetalles.CurrentCell.RowIndex].Value.ToString();
            bool resultado;
            Datos datos = new Datos();
            if (MessageBox.Show("¿estas seguro de Borrar?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string query = "Delete from facturas_detalles where id = " + id;
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
