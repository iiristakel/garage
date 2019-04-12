using System;
using System.Threading.Tasks;
using Contracts.Base;

namespace Contracts.BLL.Base
{
    public interface IBaseBLL : ITrackableInstance
    {
        Guid InstanceId { get; }

        Task<int> SaveChangesAsync();
    }
}