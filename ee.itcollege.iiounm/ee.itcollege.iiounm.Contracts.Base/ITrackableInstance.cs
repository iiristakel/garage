using System;

namespace ee.itcollege.iiounm.Contracts.Base
{
    public interface ITrackableInstance
    {
        Guid InstanceId { get; }
    }
}