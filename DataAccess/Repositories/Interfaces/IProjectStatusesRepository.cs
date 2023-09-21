using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IProjectStatusesRepository : IRepository<ProjectStatus>
    {
        Task<ProjectStatus> Update(ProjectStatus projectStatuses);
    }
}
