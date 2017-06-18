using System.Threading.Tasks;
using NetCoreSaaS.Data.Abstracts;
using NetCoreSaaS.Data.Contexts;

namespace NetCoreSaaS.Data.Repositories.UoWs
{
    public class CatalogUnitOfWork : ICatalogUnitOfWork
    {
        private readonly CatalogDbContext _context;

        public CatalogUnitOfWork(CatalogDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
