using ee.itcollege.iiounm.Contracts.Base;
using ee.itcollege.iiounm.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.iiounm.Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    
    }
    public interface IBaseEntityService<TBLLEntity> :IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, new()
    {
        
    }
}