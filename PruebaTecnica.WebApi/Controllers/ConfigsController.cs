using PruebaTecnica.WebApi.Core.Entities;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebaTecnica.WebApi.Controllers
{
    public class ConfigsController : ApiController
    {
        private readonly IConfigsService _configsService;

        public ConfigsController(IConfigsService configsService)
        {
            _configsService = configsService;
        }

        // GET: api/Configs
        public async Task<Configuraciones> Get()
        {
            var configs = await _configsService.ObtenerConfigs();

            return configs;
        }
    }
}
