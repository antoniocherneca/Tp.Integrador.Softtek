using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IProjectsRepository : IRepository<Project>
    {
        Task<Project> Update(Project project);
    }
}
