using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(IDataContext dataContext) : base(dataContext)
        {
        }
//??        
//        public async Task<IEnumerable<Bill>> AllAsync(int userId)
//        {
//            return await RepositoryDbSet
//                .Include(p => p.Client)
//                .ToListAsync();
//        }
        public override async Task<Client> FindAsync(params object[] id)
        {
            var client = await base.FindAsync(id);

            if (client != null)
            {
                await RepositoryDbContext.Entry(client).Reference(c => c.ClientGroup).LoadAsync();
            }
            
            return client;
        }
    }
}