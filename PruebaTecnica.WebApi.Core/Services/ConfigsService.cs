using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Services
{
    public class ConfigsService : IConfigsService
    {
        private readonly IConfigsRepository _configsRepository;

        public ConfigsService(IConfigsRepository configsRepository)
        {
            _configsRepository = configsRepository;
        }

        public async Task<Configuraciones> ObtenerConfigs()
        {
            return await _configsRepository.ObtenerConfigs();
        }
    }
}
