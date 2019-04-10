using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ClientGroupRepository : BaseRepository<ClientGroup>, IClientGroupRepository
    {
        public ClientGroupRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<ClientGroup>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.Clients).ToListAsync();
        }

        public virtual async Task<IEnumerable<ClientGroupDTO>> GetAllWithClientCountAsync()
        {           
            return await RepositoryDbSet
                .Select(c => new ClientGroupDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    DiscountPercent = c.DiscountPercent,
                    ClientCount = c.Clients.Count
                })
                .ToListAsync();
        }
    }
}