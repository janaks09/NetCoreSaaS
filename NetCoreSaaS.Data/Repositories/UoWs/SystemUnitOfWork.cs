using System.Threading.Tasks;
using NetCoreSaaS.Data.Abstracts;
using NetCoreSaaS.Data.Contexts;

namespace NetCoreSaaS.Data.Repositories.UoWs
{
    public class SystemUnitOfWork : ISystemUnitOfWork
    {
        private readonly SystemDbContext _context;

        public SystemUnitOfWork(SystemDbContext context)
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
