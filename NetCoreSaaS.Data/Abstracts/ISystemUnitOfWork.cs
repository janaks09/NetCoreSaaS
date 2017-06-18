using System.Threading.Tasks;

namespace NetCoreSaaS.Data.Abstracts
{
    public interface ISystemUnitOfWork
    {
        void Save();
        Task SaveAsync();

    }
}
