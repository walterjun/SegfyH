using System.Collections.Generic;
using System.Threading.Tasks;
using YouSearch.Dominio.Entidades;
using YouSearch.Dominio.Interfaces.Infra;
using YouSearch.Dominio.Interfaces.Servicos;

namespace YouSearch.Aplicacao.Servicos
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class, EntidadeBase
    {
        protected readonly IRepositorioAsync<TEntity> repository;

        public ServicoBase(IRepositorioAsync<TEntity> repository)
        {
            this.repository = repository;
        }
        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            return await repository.AddAsync(obj);
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return await repository.AddRangeAsync(entities);
        }

        public virtual async Task<IEnumerable<TEntity>> BuscarAsync()
        {
            return await repository.BuscarAsync();
        }

        public virtual async Task<TEntity> BuscarPorIdAsync(object id)
        {
            return await repository.BuscarPorIdAsync(id);
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            return await repository.DeleteAsync(id);
        }

        public virtual async Task<int> DeleteAsync(TEntity obj)
        {
            return await repository.DeleteAsync(obj);
        }

        public virtual async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            return await repository.DeleteRangeAsync(entities);
        }

        public virtual async Task<int> UpdateAsync(TEntity obj)
        {
            return await repository.UpdateAsync(obj);
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            return await repository.UpdateRangeAsync(entities);
        }
    }
}
