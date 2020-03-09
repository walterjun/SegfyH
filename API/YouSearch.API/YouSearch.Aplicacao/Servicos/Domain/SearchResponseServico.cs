using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Infra.Domain;
using YouSearch.Dominio.Interfaces.Servicos.Domain;

namespace YouSearch.Aplicacao.Servicos.Domain
{
    class SearchResponseServico : ServicoBase<SearchResponse>, ISearchResponseServico
    {
        private readonly ISearchResponseRepositorio _repository;

        public SearchResponseServico(ISearchResponseRepositorio repository) : base(repository)
        {
            _repository = repository;
        }
    }
}