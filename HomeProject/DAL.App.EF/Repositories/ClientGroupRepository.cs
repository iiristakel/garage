using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ClientGroupRepository 
        : BaseRepository<DAL.App.DTO.ClientGroup, Domain.ClientGroup,
            AppDbContext>, IClientGroupRepository
    {
        public ClientGroupRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new ClientGroupMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.ClientGroup>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Clients)
                .Select(e => ClientGroupMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public virtual async Task<List<ClientGroupWithClientCount>> GetAllWithClientCountAsync()
        {           
            return await RepositoryDbSet
                .Select(c => new ClientGroupWithClientCount()
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