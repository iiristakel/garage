using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductForClientRepository : BaseRepository<ProductForClient>, IProductForClientRepository
    {
        public ProductForClientRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}