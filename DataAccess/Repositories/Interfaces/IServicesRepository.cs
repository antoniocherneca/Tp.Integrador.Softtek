using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IServicesRepository : IRepository<Service>
    {
        Task<Service> Update(Service service);
    }
}
