using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebaTecnica.WebApi.Controllers
{
    public class TransaccionesController : ApiController
    {
        private readonly ITransaccionesService _transaccionesService;

        public TransaccionesController(ITransaccionesService transaccionesService)
        {
            _transaccionesService = transaccionesService;
        }

        [HttpGet]
        public async Task<IEnumerable<Transaccion>> ObtenerTransaccionesPorMes([FromUri] int anio, int mes)
        {
            var transacciones = await _transaccionesService.ObtenerTransaccionesPorMes(anio, mes);

            return transacciones;
        }
    }
}