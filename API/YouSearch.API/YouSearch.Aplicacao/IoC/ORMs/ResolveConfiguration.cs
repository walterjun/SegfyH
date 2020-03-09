using Microsoft.Extensions.Configuration;
using YouSearch.Infra.Configuracao;

namespace YouSearch.Aplicacao.IoC.ORMs
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? ConexaoBanco.ConnectionConfiguration;
        }
    }
}
