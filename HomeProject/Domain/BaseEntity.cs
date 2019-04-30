using System;
using Contracts.DAL.Base;

namespace Domain
{
    public abstract class BaseEntity : IDomainEntity
    {
        public int Id { get; set; }
    }
}