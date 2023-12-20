using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Services
{
    public class TransaccionesService : ITransaccionesService
    {
        private readonly ITransaccionesRepository _transaccionesRepository;

        public TransaccionesService(ITransaccionesRepository transaccionesRepository)
        {
            _transaccionesRepository = transaccionesRepository;
        }

        public async Task<List<Transaccion>> ObtenerTransaccionesPorMes(int anio, int mes)
        {
            var transacciones = await _transaccionesRepository.ObtenerTransaccionesPorMes(anio, mes);

            return transacciones;
        }
    }
}
