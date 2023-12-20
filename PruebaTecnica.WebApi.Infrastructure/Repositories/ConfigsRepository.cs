using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Infrastructure.Data;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Infrastructure.Repositories
{
    public class ConfigsRepository : IConfigsRepository
    {
        public async Task<Configuraciones> ObtenerConfigs()
        {
            Configuraciones configs = new Configuraciones();

            string consulta = "EXEC spObtenerConfiguraciones";

            using (var conexion = ConexionDb.ObtenerConexion())
            {
                var comando = new SqlCommand(consulta, conexion);

                await conexion.OpenAsync();

                var lector = await comando.ExecuteReaderAsync();

                while (await lector.ReadAsync())
                {
                    configs = new Configuraciones()
                    {
                        Id = lector.GetString(0),
                        PorcentajeInteres = lector.GetDecimal(1),
                        PorcentajeSaldoMinimo = lector.GetDecimal(2)
                    };
                }

                lector.Close();
                conexion.Close();

                return configs;
            }
        }

        public async Task ModificarConfigs(Configuraciones configs)
        {
            string consulta = "EXEC spModificarConfiguraciones";

            using (var conexion = ConexionDb.ObtenerConexion())
            {
                var comando = new SqlCommand(consulta, conexion);
                comando.CommandType = CommandType.StoredProcedure;

                // Parametros de procedimiento almacenado
                comando.Parameters.Add(new SqlParameter("@PorcentajeInteres", configs.PorcentajeInteres));
                comando.Parameters.Add(new SqlParameter("@PorcentajeSaldoMinimo", configs.PorcentajeSaldoMinimo));

                await conexion.OpenAsync();

                await comando.ExecuteNonQueryAsync();

                conexion.Close();
            }
        }
    }
}
