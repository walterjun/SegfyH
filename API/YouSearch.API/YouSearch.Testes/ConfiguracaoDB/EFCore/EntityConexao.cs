using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using YouSearch.Infra.Configuracao.EFCore;

namespace YouSearch.Testes.ConfiguracaoDB.EFCore
{
    public class EntityConexao
    {
        private IServiceProvider _provider;

        public AplicacaoContexto DataBaseConfiguration()
        {
            var services = new ServiceCollection();
            services.AddDbContext<AplicacaoContexto>(options => options.UseSqlServer(ConexaoBanco.ConnectionConfiguration.Value.DefaultConnection));
            _provider = services.BuildServiceProvider();
            return _provider.GetService<AplicacaoContexto>();
        }
    }
}
