using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IServicesRepository
    {
        public IEnumerable<Service> GetAll();
        public Service GetById(int id);
        public void Create(Service service);
        public void Update(Service service);
        public void Delete(int id);
    }
}
