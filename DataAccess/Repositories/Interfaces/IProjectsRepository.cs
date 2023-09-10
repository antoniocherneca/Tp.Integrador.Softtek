using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IProjectsRepository
    {
        public IEnumerable<Project> GetAll();
        public Project GetById(int id);
        public void Create(Project project);
        public void Update(Project project);
        public void Delete(int id);
    }
}
