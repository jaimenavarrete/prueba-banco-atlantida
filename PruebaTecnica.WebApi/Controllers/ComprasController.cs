using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebaTecnica.WebApi.Controllers
{
    public class ComprasController : ApiController
    {
        private readonly IComprasService _comprasService;

        public ComprasController(IComprasService comprasService)
        {
            _comprasService = comprasService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertarCompra(Compra compra)
        {
            var compraCreada = await _comprasService.InsertarCompra(compra);

            return Created("", compraCreada);
        }
    }
}
