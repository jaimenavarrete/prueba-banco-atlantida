using PruebaTecnica.WebApi.Core.Entities;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Interfaces.Services
{
    public interface IComprasService
    {
        Task<Compra> InsertarCompra(Compra compra);
    }
}
