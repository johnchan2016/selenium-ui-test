using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RMSUI.Test
{
    public static class Initializer
    {
        public static IContainer Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IConfiguration>(sp =>
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("appsettings.json");
                return configurationBuilder.Build();
            });

            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);

            return builder.Build();
        }
    }
}
