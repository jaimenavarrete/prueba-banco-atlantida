using PruebaTecnica.WebApi.Core.Entities;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Interfaces.Services
{
    public interface ICuentasService
    {
        Task<EstadoCuenta> ObtenerEstadoCuenta();
    }
}
