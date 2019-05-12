namespace ee.itcollege.iiounm.Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceProvider
    {
        TService GetService<TService>();
//        IBaseEntityService<TEntity> GetEntityService<TEntity>() where TEntity : class, IBaseEntity, new();
    }
}
