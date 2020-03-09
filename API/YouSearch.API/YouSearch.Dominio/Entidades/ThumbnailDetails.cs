namespace YouSearch.Dominio.Entidades
{
    public class ThumbnailDetails : EntidadeBase
    {
        public virtual Thumbnail Default__ { get; set; }
        public virtual Thumbnail High { get; set; }
        public virtual Thumbnail Maxres { get; set; }
        public virtual Thumbnail Medium { get; set; }
        public virtual Thumbnail Standard { get; set; }
        public virtual string ETag { get; set; }
        public int Id { get; set; }
    }
}
