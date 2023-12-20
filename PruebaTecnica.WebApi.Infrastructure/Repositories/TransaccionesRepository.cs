using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Infrastructure.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Infrastructure.Repositories
{
    public class TransaccionesRepository : ITransaccionesRepository
    {
        public async Task<List<Transaccion>> ObtenerTransaccionesPorMes(int anio, int mes)
        {
            var transacciones = new List<Transaccion>();

            string procedimiento = "spObtenerTransaccionesPorMes";

            using (var conexion = ConexionDb.ObtenerConexion())
            {
                var comando = new SqlCommand(procedimiento, conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add(new SqlParameter("@Anio", anio));
                comando.Parameters.Add(new SqlParameter("@Mes", mes));

                await conexion.OpenAsync();

                var lector = await comando.ExecuteReaderAsync();

                while (await lector.ReadAsync())
                {
                    var transaccion = new Transaccion()
                    {
                        Id = lector.GetString(0),
                        Monto = lector.GetDecimal(2),
                        FechaTransaccion = lector.GetDateTime(3)
                    };

                    transacciones.Add(transaccion);
                }

                lector.Close();
                conexion.Close();

                return transacciones;
            }
        }
    }
}
