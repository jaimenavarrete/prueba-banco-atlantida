using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace PruebaTecnica.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Serializar a JSON todas las respuestas del servidor
            var formateador = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formateador.SerializerSettings.ContractResolver = 
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
