using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IProjectStatusesRepository
    {
        public IEnumerable<ProjectStatus> GetAll();
        public ProjectStatus GetById(int id);
        public void Create(ProjectStatus projectStatus);
        public void Update(ProjectStatus projectStatus);
        public void Delete(int id);
    }
}
