using Microsoft.EntityFrameworkCore;

namespace NetCoreSaaS.Data.Contexts
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {

        }

    }
}
