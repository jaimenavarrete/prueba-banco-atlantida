using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Infrastructure.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Infrastructure.Repositories
{
    public class CuentasRepository : ICuentasRepository
    {
        public async Task<Cuenta> ObtenerCuenta()
        {
            Cuenta cuenta = new Cuenta();

            string consulta = "EXEC spObtenerCuenta";

            using (var conexion = ConexionDb.ObtenerConexion())
            {
                var comando = new SqlCommand(consulta, conexion);

                await conexion.OpenAsync();

                var lector = await comando.ExecuteReaderAsync();

                while(await lector.ReadAsync())
                {
                    cuenta = new Cuenta()
                    {
                        Id = lector.GetString(0),
                        NombreTitular = lector.GetString(1),
                        NumeroTarjeta = lector.GetString(2)
                    };
                }

                lector.Close();
                conexion.Close();

                return cuenta;
            }
        }
    }
}
