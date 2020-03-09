using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Infra.Domain;
using YouSearch.Dominio.Interfaces.Servicos.Domain;

namespace YouSearch.Aplicacao.Servicos.Domain
{
    public class PageInfoServico : ServicoBase<PageInfo>, IPageInfoServico
    {
        private readonly IPageInfoRepositorio _repository;

        public PageInfoServico(IPageInfoRepositorio repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
