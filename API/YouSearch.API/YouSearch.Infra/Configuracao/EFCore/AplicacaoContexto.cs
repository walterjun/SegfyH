using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YouSearch.Dominio.Entidades;

namespace YouSearch.Infra.Configuracao.EFCore
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseMySQL(ConexaoBanco.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> options) : base(options)
        {
        }

        public DbSet<SearchResponse> SearchResponse { get; set; }
        public DbSet<PageInfo> PageInfo { get; set; }
        public DbSet<SearchResultSnippet> SearchResultSnippet { get; set; }
        public DbSet<Thumbnail> Thumbnail { get; set; }
        public DbSet<ThumbnailDetails> ThumbnailDetails { get; set; }
    }
}