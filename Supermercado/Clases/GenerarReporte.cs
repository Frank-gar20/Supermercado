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
                    string Query = "Select id,nombre,apellido from clientes"; //aqui se modifica la query segun lo que
                                                                              //tengamos en el reporte .rtp

                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(Query, connection);

                    DataSetApp ds = new DataSetApp();
                    dataAdapter.Fill(ds, "Clientes");

                    ReportDocument reporte = new ReportDocument();

                    reporte.Load(@"C:\Users\carri\source\repos\Supermercado\Supermercado\Informe.rpt");
                    reporte.SetDataSource(ds.Tables["Clientes"]);
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
