using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class JobsRepository : Repository<Job>, IJobsRepository
    {
        private readonly ApplicationDbContext _context;

        public JobsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Job> Update(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();

            return job;
        }
    }
}
