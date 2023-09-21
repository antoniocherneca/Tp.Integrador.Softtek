using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IRolesRepository : IRepository<Role>
    {
        Task<Role> Update(Role role);
    }
}
