using System.Data.SqlClient;
using System.Configuration;

namespace PruebaTecnica.WebApi.Infrastructure.Data
{
    public class ConexionDb
    {
        public static SqlConnection ObtenerConexion()
        {
            // Lee enlace de conexion desde Web.config
            var enlaceConexion = ConfigurationManager
                    .ConnectionStrings["BancoAtlantida"].ConnectionString;

            var conexion = new SqlConnection(enlaceConexion);

            return conexion;
        }
    }
}
