using Autofac;
using Autofac.Integration.WebApi;
using PruebaTecnica.WebApi.Core.Interfaces.Repositories;
using PruebaTecnica.WebApi.Core.Interfaces.Services;
using PruebaTecnica.WebApi.Core.Interfaces.Tools;
using PruebaTecnica.WebApi.Core.Services;
using PruebaTecnica.WebApi.Infrastructure.Others;
using PruebaTecnica.WebApi.Infrastructure.Repositories;
using System.Reflection;
using System.Web.Http;

namespace PruebaTecnica.WebApi
{
    public static class ContainerConfig
    {
        private static ContainerBuilder RegisterDependencies(ContainerBuilder builder)
        {
            // Servicios
            builder.RegisterType<CuentasService>().As<ICuentasService>();
            builder.RegisterType<ConfigsService>().As<IConfigsService>();

            // Repositorios
            builder.RegisterType<CuentasRepository>().As<ICuentasRepository>();
            builder.RegisterType<ConfigsRepository>().As<IConfigsRepository>();

            // Otros
            builder.RegisterType<EncriptadorService>().As<IEncriptadorService>();

            return builder;
        }

        public static void Configure(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder = RegisterDependencies(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            configuration.DependencyResolver = resolver;
        }
    }
}