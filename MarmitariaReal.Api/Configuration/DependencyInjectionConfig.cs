using MarmitariaReal.Domain.Interfaces.Repositories;
using MarmitariaReal.Domain.Interfaces.Services;
using MarmitariaReal.Repositories.Repositories.ExternalRepositories;
using MarmitariaReal.Repositories.Repositories;
using MarmitariaReal.Services.Services;

namespace MarmitariaReal.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IReceitasService, ReceitasService>();
            services.AddScoped<IReceitasRepository, ReceitasRepository>();
            services.AddScoped<IAzureBlobStorageRepository, AzureBlobStorageRepository>();
        }
    }
}
