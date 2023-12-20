using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Services
{
    public class ComprasService : IComprasService
    {
        private readonly IComprasRepository _comprasRepository;

        public ComprasService(IComprasRepository comprasRepository)
        {
            _comprasRepository = comprasRepository;
        }

        public async Task<Compra> InsertarCompra(Compra compra)
        {
            var compraCreada = await _comprasRepository.InsertarCompra(compra);

            return compraCreada;
        }
    }
}
