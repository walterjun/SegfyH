using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Infra.Domain;
using YouSearch.Infra.Configuracao.EFCore;

namespace YouSearch.Infra.Repositorios.EFCore
{
    public class PageInfoRepositorio : RepositorioAsync<PageInfo>, IPageInfoRepositorio
    {
        public PageInfoRepositorio(AplicacaoContexto contexto) : base(contexto)
        {

        }
    }
}