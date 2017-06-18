using System.Threading.Tasks;

namespace NetCoreSaaS.Data.Abstracts
{
    public interface ITenantUnitOfWork
    {
        void Save();
        Task SaveAsync();

    }
}
