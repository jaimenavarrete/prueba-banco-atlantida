using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebaTecnica.WebApi.Controllers
{
    public class CuentasController : ApiController
    {
        private readonly ICuentasService _cuentasService;

        public CuentasController(ICuentasService cuentasService)
        {
            _cuentasService = cuentasService;
        }

        [Route("api/cuenta/estadoCuenta")]
        [HttpGet]
        public async Task<EstadoCuenta> ObtenerEstadoCuenta()
        {
            var estadoCuenta = await _cuentasService.ObtenerEstadoCuenta();

            return estadoCuenta;
        }
    }
}
