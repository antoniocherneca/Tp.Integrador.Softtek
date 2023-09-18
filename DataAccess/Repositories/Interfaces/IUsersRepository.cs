using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> Update(User user);
    }
}
