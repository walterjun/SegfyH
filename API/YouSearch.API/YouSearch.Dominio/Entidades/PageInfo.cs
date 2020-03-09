namespace YouSearch.Dominio.Entidades
{
    public class PageInfo : EntidadeBase
    {
        public int Id { get; set; }
        public int totalResults { get; set; }
        public int resultsPerPage { get; set; }
    }
}
