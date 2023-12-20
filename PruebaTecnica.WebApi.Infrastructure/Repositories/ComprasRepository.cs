using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Infrastructure.Data;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Infrastructure.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        public async Task<Compra> InsertarCompra(Compra compra)
        {
            string procedimiento = "spInsertarCompra";

            using (var conexion = ConexionDb.ObtenerConexion())
            {
                var comando = new SqlCommand(procedimiento, conexion);
                comando.CommandType = CommandType.StoredProcedure;

                // Parametros de procedimiento almacenado
                comando.Parameters.Add(new SqlParameter("@Id", compra.Id));
                comando.Parameters.Add(new SqlParameter("@Descripcion", compra.Descripcion));
                comando.Parameters.Add(new SqlParameter("@Monto", compra.Monto));
                comando.Parameters.Add(new SqlParameter("@FechaCompra", compra.FechaTransaccion));

                await conexion.OpenAsync();

                await comando.ExecuteNonQueryAsync();

                conexion.Close();

                return compra;
            }
        }
    }
}
