using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class ProjectStatusesRepository : Repository<ProjectStatus>, IProjectStatusesRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectStatusesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProjectStatus> Update(ProjectStatus projectStatus)
        {
            _context.ProjectStatuses.Update(projectStatus);
            await _context.SaveChangesAsync();

            return projectStatus;
        }
    }
}
