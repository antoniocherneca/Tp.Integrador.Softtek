using System.Data;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IRolesRepository
    {
        public IEnumerable<Role> GetAll();
        public Role GetById(int id);
        public void Create(Role role);
        public void Update(Role role);
        public void Delete(int id);
    }
}
