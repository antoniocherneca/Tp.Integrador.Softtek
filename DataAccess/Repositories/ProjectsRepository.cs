using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class ProjectsRepository : Repository<Project>, IProjectsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Project> Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return project;
        }
    }
}
