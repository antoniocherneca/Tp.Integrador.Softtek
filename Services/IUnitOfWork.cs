using Tp.Integrador.Softtek.DataAccess.Repositories;

namespace Tp.Integrador.Softtek.Services
{
    public interface IUnitOfWork
    {
        public UsersRepository UsersRepository { get; }
        public ProjectsRepository ProjectsRepository { get; }
        public ServicesRepository ServicesRepository { get; }
        public JobsRepository JobsRepository { get; }
        public RolesRepository RolesRepository { get; }
        public ProjectStatusesRepository ProjectStatusesRepository { get; }


        Task<int> Complete();
    }
}
