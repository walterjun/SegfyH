using Microsoft.Extensions.DependencyInjection;
using YouSearch.Aplicacao.Servicos;
using YouSearch.Aplicacao.Servicos.Domain;
using YouSearch.Dominio.Interfaces.Servicos;
using YouSearch.Dominio.Interfaces.Servicos.Domain;

namespace YouSearch.Aplicacao.IoC
{
    public static class ServicosIoC
    {
        public static void ServicosAplicacaoIoC(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));

            services.AddScoped<IPageInfoServico, PageInfoServico>();
            services.AddScoped<ISearchResponseServico, SearchResponseServico>();
        }
    }
}
