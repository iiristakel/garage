using System;

namespace Contracts.DAL.Base
{
    /// <summary>
    /// Int based interface for required entity meta fields like PK, CreateBy, CreatedAt etc...
    /// </summary>
    public interface IBaseEntity : IBaseEntity<int>
    {
        
    }
    
    /// <summary>
    /// Generic interface for entity meta fields
    /// </summary>
    /// <typeparam name="TKey">primary key type</typeparam>
    public interface IBaseEntity<TKey> 
        where TKey: IComparable
    {
        TKey Id { get; set;}
    }
}