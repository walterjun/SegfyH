using System;

namespace YouSearch.Dominio.Entidades
{
    public class SearchResultSnippet : EntidadeBase
    {
        public virtual string ChannelId { get; set; }
        public virtual string ChannelTitle { get; set; }
        public virtual string Description { get; set; }
        public virtual string LiveBroadcastContent { get; set; }
        public virtual string PublishedAtRaw { get; set; }
        public virtual DateTime? PublishedAt { get; set; }
        public virtual ThumbnailDetails Thumbnails { get; set; }
        public virtual string Title { get; set; }
        public virtual string ETag { get; set; }
        public int Id { get; set; }
    }
}
