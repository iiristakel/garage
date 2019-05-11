using System.Threading.Tasks;

namespace ee.itcollege.iiounm.Contracts.DAL.Base
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}