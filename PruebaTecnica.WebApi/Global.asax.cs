using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace PruebaTecnica.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Configuración de Inyección de Dependencias
            ContainerConfig.Configure(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
