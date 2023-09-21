using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class RolesRepository : Repository<Role>, IRolesRepository
    {
        private readonly ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> Update(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();

            return role;
        }
    }
}
