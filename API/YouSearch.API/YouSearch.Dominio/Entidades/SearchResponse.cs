namespace YouSearch.Dominio.Entidades
{
    public class SearchResponse : EntidadeBase
    {
        public string Kind { get; set; }
        public string ETag { get; set; }
        public SearchResultSnippet Snippet { get; set; }
        public int Id { get; set; }
    }
}
