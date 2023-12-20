using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Services
{
    public class PagosService : IPagosService
    {
        private readonly IPagosRepository _pagosRepository;

        public PagosService(IPagosRepository pagosRepository)
        {
            _pagosRepository = pagosRepository;

        }
        public async Task<Pago> InsertarPago(Pago pago)
        {
            var pagoCreado = await _pagosRepository.InsertarPago(pago);

            return pagoCreado;
        }
    }
}
