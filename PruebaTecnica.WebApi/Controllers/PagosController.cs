using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebaTecnica.WebApi.Controllers
{
    public class PagosController : ApiController
    {
        private readonly IPagosService _pagosService;

        public PagosController(IPagosService pagosService)
        {
            _pagosService = pagosService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertarCompra(Pago pago)
        {
            var pagoCreado = await _pagosService.InsertarPago(pago);

            return Created("", pagoCreado);
        }
    }
}
