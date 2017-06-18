using System.Threading.Tasks;

namespace NetCoreSaaS.Data.Abstracts
{
    public interface ICatalogUnitOfWork
    {
        void Save();
        Task SaveAsync();

    }
}
