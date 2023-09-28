using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Helpers;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        private string secretKey;

        public UsersRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            
            return user;
        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDto authDto)
        {
            return await _context.Users.Include(u => u.Role).SingleOrDefaultAsync(u => u.Email == authDto.Email && u.Password == PasswordEncryptHelper.EncryptPassword(authDto.Password, authDto.Email));
        }

        public async Task<bool> UserExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
