using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        bool isSingleUser(string userName);

        Task<User> Update(User user);

        //Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        //Task<User> Register(RegisterRequestDto registerRequestDto);
    }
}
