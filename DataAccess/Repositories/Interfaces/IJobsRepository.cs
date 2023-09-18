using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IJobsRepository : IRepository<Job>
    {
        Task<Job> Update(Job job);
    }
}
