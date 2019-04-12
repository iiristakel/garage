using System;
using System.Threading.Tasks;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public class IAppBLL : IBaseBLL
    {
        public Guid InstanceId { get; }
        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}