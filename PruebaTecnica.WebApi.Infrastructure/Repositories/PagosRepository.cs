using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Infrastructure.Data;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Infrastructure.Repositories
{
    public class PagosRepository : IPagosRepository
    {
        public async Task<Pago> InsertarPago(Pago pago)
        {
            string procedimiento = "spInsertarPago";

            using (var conexion = ConexionDb.ObtenerConexion())
            {
                var comando = new SqlCommand(procedimiento, conexion);
                comando.CommandType = CommandType.StoredProcedure;

                // Parametros de procedimiento almacenado
                comando.Parameters.Add(new SqlParameter("@Id", pago.Id));
                comando.Parameters.Add(new SqlParameter("@Monto", pago.Monto));
                comando.Parameters.Add(new SqlParameter("@FechaPago", pago.FechaTransaccion));
                comando.Parameters.Add(new SqlParameter("@CuentaId", "454a540a-f481-430c-a7ce-6a1516732ff4"));

                await conexion.OpenAsync();

                await comando.ExecuteNonQueryAsync();

                conexion.Close();

                return pago;
            }
        }
    }
}
