using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Xunit;
using YouSearch.Dominio.Interfaces.Infra.Domain;
using YouSearch.Infra.Configuracao.EFCore;
using YouSearch.Infra.Repositorios.EFCore;
using YouSearch.Testes.ConfiguracaoDB.EFCore;
using YouSearch.Testes.DataBuilder;

namespace YouSearch.Testes
{
    public class PageInfoTeste : IClassFixture<EntityConexao>, IDisposable
    {
        private AplicacaoContexto dbContext;
        private IDbContextTransaction transaction;
        private PageInfoBuilder builder;
        private IPageInfoRepositorio userEntityFramework;

        public PageInfoTeste(EntityConexao entityConexao)
        {
            dbContext = entityConexao.DataBaseConfiguration();
            userEntityFramework = new PageInfoRepositorio(dbContext);
            this.builder = new PageInfoBuilder();
            transaction = dbContext.Database.BeginTransaction();
        }

        [Fact]
        public async Task AddAsync()
        {
            var result = await userEntityFramework.AddAsync(builder.CriarPageInfo());
            Assert.True(result.Id > 0);
        }

        public void Dispose()
        {
            transaction.Rollback();
        }
    }
}
