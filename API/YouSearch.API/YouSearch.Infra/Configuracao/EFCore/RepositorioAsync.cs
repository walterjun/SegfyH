using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Infra;

namespace YouSearch.Infra.Configuracao.EFCore
{
    public class RepositorioAsync<TEntidade> : IRepositorioAsync<TEntidade> where TEntidade : class, EntidadeBase
    {

        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntidade> dbSet;

        protected RepositorioAsync(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntidade>();
        }

        //public void Dispose()
        //{
        //    dbContext.Dispose();
        //    GC.SuppressFinalize(this);
        //}

        public virtual async Task<TEntidade> AddAsync(TEntidade obj)
        {
            var r = await dbSet.AddAsync(obj);
            await CommitAsync();
            return r.Entity;
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<TEntidade> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await CommitAsync();
        }

        public virtual async Task<IEnumerable<TEntidade>> BuscarAsync()
        {
            return await Task.FromResult(dbSet);
        }

        public virtual async Task<TEntidade> BuscarPorIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            TEntidade entity = await BuscarPorIdAsync(id);

            if (entity == null) return false;

            return await DeleteAsync(entity) > 0 ? true : false;
        }

        public virtual async Task<int> DeleteAsync(TEntidade obj)
        {
            dbSet.Remove(obj);
            return await CommitAsync();
        }

        public virtual async Task<int> DeleteRangeAsync(IEnumerable<TEntidade> entities)
        {
            dbSet.RemoveRange(entities);
            return await CommitAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntidade obj)
        {
            var avoidingAttachedEntity = await BuscarPorIdAsync(obj.Id);
            dbContext.Entry(avoidingAttachedEntity).State = EntityState.Detached;

            var entry = dbContext.Entry(obj);
            if (entry.State == EntityState.Detached) dbContext.Attach(obj);

            dbContext.Entry(obj).State = EntityState.Modified;
            return await CommitAsync();
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntidade> entities)
        {
            dbSet.UpdateRange(entities);
            return await CommitAsync();
        }

        private async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}

