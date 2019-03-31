using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public override async Task<IEnumerable<ProductForClient>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .Include(p => p.Product)
                .Include(p => p.WorkObject)
                .ToListAsync();
        }
        
        public override async Task<ProductForClient> FindAsync(params object[] id)
        {
            var productForClient = await base.FindAsync(id);

            if (productForClient != null)
            {
                await RepositoryDbContext.Entry(productForClient).Reference(c => c.Client).LoadAsync();
                await RepositoryDbContext.Entry(productForClient).Reference(c => c.Product).LoadAsync();
                await RepositoryDbContext.Entry(productForClient).Reference(c => c.WorkObject).LoadAsync();

            }
            
            return productForClient;
        }
    }
}