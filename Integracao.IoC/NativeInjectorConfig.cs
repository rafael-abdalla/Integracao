using Integracao.Data.Context;
using Integracao.Data.Repositories;
using Integracao.Domain.Interfaces.Services;
using Integracao.Domain.Repositories;
using Integracao.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integracao.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<IntegracaoContext>(options =>
            //{
            //    options.UseInMemoryDatabase("Integracao");
            //});

            services.AddDbContextPool<IntegracaoContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IIntegracaoService, IntegracaoService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoIntegracaoRepository, ProdutoIntegracaoRepository>();
        }
    }
}