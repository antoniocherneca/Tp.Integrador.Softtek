using Tp.Integrador.Softtek.DataAccess.Repositories;

namespace Tp.Integrador.Softtek.Services
{
    public interface IUnitOfWork
    {
        public UsersRepository UsersRepository { get; }
        public ProjectsRepository ProjectsRepository { get; }
        public ServicesRepository ServicesRepository { get; }
        public JobsRepository JobsRepository { get; }

        Task<int> Complete();
    }
}
