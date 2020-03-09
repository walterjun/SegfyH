using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Infra.Domain;
using YouSearch.Infra.Configuracao.EFCore;

namespace YouSearch.Infra.Repositorios.EFCore
{
    public class SearchResponseRepositorio : RepositorioAsync<SearchResponse>, ISearchResponseRepositorio
    {
        public SearchResponseRepositorio(AplicacaoContexto contexto): base(contexto)
        {

        }
    }
}
