using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YouSearch.Dominio.Interfaces.Infra;
using YouSearch.Dominio.Interfaces.Infra.Domain;
using YouSearch.Infra.Configuracao.EFCore;
using YouSearch.Infra.Repositorios.EFCore;

namespace YouSearch.Aplicacao.IoC.ORMs.EFCore
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicacaoContexto>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepositorioAsync<>), typeof(RepositorioAsync<>));
            services.AddScoped<IPageInfoRepositorio, PageInfoRepositorio>();
            services.AddScoped<ISearchResponseRepositorio, SearchResponseRepositorio>();

            return services;
        }
    }
}
