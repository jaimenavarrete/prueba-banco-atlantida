using PruebaTecnica.WebApi.Core.Entities;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Interfaces.Repositories
{
    public interface IPagosRepository
    {
        Task<Pago> InsertarPago(Pago pago);
    }
}
