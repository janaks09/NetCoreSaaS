using System.Threading.Tasks;
using NetCoreSaaS.Data.Abstracts;
using NetCoreSaaS.Data.Contexts;

namespace NetCoreSaaS.Data.Repositories.UoWs
{
    public class TenantUnitOfWork : ITenantUnitOfWork
    {

        private readonly TenantDbContext _context;

        public TenantUnitOfWork(TenantDbContext context)
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
