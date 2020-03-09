namespace YouSearch.Dominio.Entidades
{
    public class Thumbnail : EntidadeBase
    {
        public virtual long? Height { get; set; }
        public virtual string Url { get; set; }
        public virtual long? Width { get; set; }
        public virtual string ETag { get; set; }
        public int Id { get; set; }
    }
}
