using PruebaTecnica.WebApi.Core.Entities;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Interfaces.Repositories
{
    public interface IConfigsRepository
    {
        Task<Configuraciones> ObtenerConfigs();
    }
}
