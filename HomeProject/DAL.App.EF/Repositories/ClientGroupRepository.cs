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
    public class ClientGroupRepository : BaseRepository<ClientGroup, AppDbContext>, IClientGroupRepository
    {
        public ClientGroupRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<ClientGroup>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.Clients).ToListAsync();
        }

        public virtual async Task<List<ClientGroupDTO>> GetAllWithClientCountAsync()
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