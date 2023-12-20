using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using PruebaTecnica.WebApi.Core.Interfaces.Tools;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Services
{
    public class CuentasService : ICuentasService
    {
        private readonly ICuentasRepository _cuentasRepository;
        private readonly IEncriptadorService _encriptadorService;

        public CuentasService(
            ICuentasRepository cuentasRepository, 
            IEncriptadorService encriptadorService)
        {
            _cuentasRepository = cuentasRepository;
            _encriptadorService = encriptadorService;
        }

        public async Task<EstadoCuenta> ObtenerEstadoCuenta()
        {
            var estadoCuenta = await _cuentasRepository.ObtenerEstadoCuenta();

            estadoCuenta.NumeroTarjeta = 
                _encriptadorService.Desencriptar(estadoCuenta.NumeroTarjeta);

            return estadoCuenta;
        }
    }
}
