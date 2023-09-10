using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class ProjectStatusesRepository : IProjectStatusesRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectStatusesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectStatus> GetAll()
        {
            return _context.ProjectStatuses.ToList();
        }

        public ProjectStatus GetById(int id)
        {
            return _context.ProjectStatuses.FirstOrDefault(ps => ps.ProjectStatusId == id);
        }

        public void Create(ProjectStatus projectStatus)
        {
            _context.ProjectStatuses.Add(projectStatus);
            _context.SaveChanges();
        }

        public void Update(ProjectStatus projectStatus)
        {
            _context.ProjectStatuses.Update(projectStatus);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var projectStatus = _context.ProjectStatuses.FirstOrDefault(ps => ps.ProjectStatusId == id);
            if (projectStatus != null)
            {
                _context.ProjectStatuses.Remove(projectStatus);
                _context.SaveChanges();
            }
        }
    }
}
