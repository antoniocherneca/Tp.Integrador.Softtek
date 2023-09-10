using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IJobsRepository
    {
        public IEnumerable<Job> GetAll();
        public Job GetById(int id);
        public void Create(Job job);
        public void Update(Job job);
        public void Delete(int id);
    }
}
