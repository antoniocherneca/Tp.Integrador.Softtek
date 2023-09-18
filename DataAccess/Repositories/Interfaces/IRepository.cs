using System.Linq.Expressions;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {        
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);

        Task<T> GetById(Expression<Func<T, bool>>? filter = null, bool tracked = true);

        Task Create(T entity);

        Task Delete(T entity);

        Task Save();

        // No tengo la implementación del "Update" porque es diferente para cada entidad
    }
}
