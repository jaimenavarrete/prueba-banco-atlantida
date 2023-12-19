using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace PruebaTecnica.WebApi
{
    public static class ContainerConfig
    {
        private static ContainerBuilder RegisterDependencies(ContainerBuilder builder)
        {
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