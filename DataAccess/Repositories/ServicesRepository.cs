using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.Repositories
{
    public class ServicesRepository : Repository<Service>, IServicesRepository
    {
        private readonly ApplicationDbContext _context;

        public ServicesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Service> Update(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();

            return service;
        }
    }
}
