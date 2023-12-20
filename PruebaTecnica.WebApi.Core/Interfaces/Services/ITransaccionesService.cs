using PruebaTecnica.WebApi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Interfaces.Services
{
    public interface ITransaccionesService
    {
        Task<List<Transaccion>> ObtenerTransaccionesPorMes(int anio, int mes);
    }
}
