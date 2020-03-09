using YouSearch.Dominio.Entidades;

namespace YouSearch.Testes.DataBuilder
{
    public class PageInfoBuilder
    {
        private PageInfo pageInfo;

        public PageInfo CriarPageInfo()
        {
            this.pageInfo = new PageInfo()
            {
                resultsPerPage = 10,
                totalResults = 100
            };
            return this.pageInfo;
        }
    }
}
