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

        public async Task<EstadoCuenta> ObtenerEstadoCuenta()
        {
            EstadoCuenta estadoCuenta = new EstadoCuenta();

            string consulta = "EXEC spObtenerEstadoCuenta";

            using (var conexion = ConexionDb.ObtenerConexion())
            {
                var comando = new SqlCommand(consulta, conexion);

                await conexion.OpenAsync();

                var lector = await comando.ExecuteReaderAsync();

                while (await lector.ReadAsync())
                {
                    estadoCuenta = new EstadoCuenta()
                    {
                        Id = lector.GetString(0),
                        NombreTitular = lector.GetString(1),
                        NumeroTarjeta = lector.GetString(2),
                        SaldoTotal = lector.GetDecimal(3),
                        LimiteCredito = lector.GetDecimal(4),
                        SaldoDisponible = lector.GetDecimal(5),
                        MontoComprasMesAnterior = lector.GetDecimal(6),
                        MontoComprasMesActual = lector.GetDecimal(7),
                        InteresBonificable = lector.GetDecimal(8),
                        CuotaMinima = lector.GetDecimal(9),
                        SaldoTotalConInteres = lector.GetDecimal(10),
                    };
                }

                lector.Close();
                conexion.Close();

                return estadoCuenta;
            }
        }
    }
}
