using Microsoft.EntityFrameworkCore;

namespace Tp.Integrador.Softtek.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
