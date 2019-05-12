using System;
using ee.itcollege.iiounm.Contracts.BLL.Base.Services;

namespace ee.itcollege.iiounm.BLL.Base.Services
{
    public class BaseService : IBaseService
    {
        private readonly Guid _instanceId = Guid.NewGuid();
        public Guid InstanceId => _instanceId;
    }
}   
