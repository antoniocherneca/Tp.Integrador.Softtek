using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ApplicationDbContext _context;

        public JobsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Job> GetAll()
        {
            return _context.Jobs.ToList();
        }

        public Job GetById(int id)
        {
            return _context.Jobs.FirstOrDefault(j => j.JobId == id);
        }

        public void Create(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public void Update(Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var job = _context.Jobs.FirstOrDefault(j => j.JobId == id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }
    }
}
