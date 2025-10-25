using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;

namespace Supermercado.Clases
{
    internal class GenerarReporte
    {
        string connectionString = "Host=localhost;Port=5432;Database=Supermercado;Username=admin;Password=jose";
        public ReportDocument CrearReporte()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    string Query = @"SELECT 
                            c.nombre AS nombre_cliente,
                            c.apellido AS apellido_cliente,
                            p.id AS id_producto,
                            p.nombre AS nombre_producto,
                            p.marca AS marca,
                            vp.cantidad
                            FROM clientes c
                            LEFT JOIN compras_clientes cc ON c.id = cc.id_cliente
                            INNER JOIN ventas v ON cc.id_venta = v.id
                            INNER JOIN ventas_productos vp ON v.id = vp.id_venta
                            INNER JOIN productos p ON vp.id_producto = p.id;";

                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(Query, connection);

                    DataSetApp ds = new DataSetApp();
                    dataAdapter.Fill(ds, "ClientesProducto");

                    ReportDocument reporte = new ReportDocument();

                    reporte.Load(@"C:\Users\carri\source\repos\Supermercado\Supermercado\Informe.rpt");
                    reporte.SetDataSource(ds.Tables["ClientesProducto"]);
                    return reporte;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al generar el reporte: " + ex.Message);
                }
            }
        }
    }
}
