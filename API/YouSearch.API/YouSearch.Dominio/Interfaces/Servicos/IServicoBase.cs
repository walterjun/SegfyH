using System.Collections.Generic;
using System.Threading.Tasks;

namespace YouSearch.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entidades);

        Task<TEntity> BuscarPorIdAsync(object id);
        Task<IEnumerable<TEntity>> BuscarAsync();

        Task<int> UpdateAsync(TEntity obj);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entidades);

        Task<bool> DeleteAsync(object id);
        Task<int> DeleteAsync(TEntity obj);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> entidades);
    }
}
