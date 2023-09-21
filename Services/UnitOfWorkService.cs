using Tp.Integrador.Softtek.DataAccess;
using Tp.Integrador.Softtek.DataAccess.Repositories;

namespace Tp.Integrador.Softtek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository UsersRepository { get; private set; }
        public ProjectsRepository ProjectsRepository { get; private set; }
        public ServicesRepository ServicesRepository { get; private set; }
        public JobsRepository JobsRepository { get; private set; }
        public RolesRepository RolesRepository { get; private set; }
        public ProjectStatusesRepository ProjectStatusesRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UsersRepository = new UsersRepository(_context);
            ProjectsRepository = new ProjectsRepository(_context);
            ServicesRepository = new ServicesRepository(_context);
            JobsRepository = new JobsRepository(_context);
            RolesRepository = new RolesRepository(_context);
            ProjectStatusesRepository = new ProjectStatusesRepository(_context);
        }
        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
