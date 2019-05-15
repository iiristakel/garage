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
    public class ClientRepository 
        : BaseRepository<DAL.App.DTO.Client, Domain.Client,
            AppDbContext>, IClientRepository
    {
        public ClientRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new ClientMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Client>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.ClientGroup)
                .Include(p => p.ProductsForClient)
                .Select(e => ClientMapper.MapFromDomain(e))
                .ToListAsync();
        }
        public override async Task<DAL.App.DTO.Client> FindAsync(params object[] id)
        {
            var client = await RepositoryDbSet.FindAsync(id);

            if (client != null)
            {
                await RepositoryDbContext.Entry(client).Reference(c => c.ClientGroup).LoadAsync();
                await RepositoryDbContext.Entry(client).Collection(c => c.ProductsForClient).LoadAsync();

            }
            
            return ClientMapper.MapFromDomain(client);
        }

        public virtual async Task<List<ClientWithProductsCount>> GetAllWithProductsCountAsync()
        {
            return await RepositoryDbSet
                .Select(c => new ClientWithProductsCount()
                {
                    Id = c.Id,
                    ClientGroup = ClientGroupMapper.MapFromDomain(c.ClientGroup),
                    ClientGroupId = c.ClientGroupId,
                    ProductsCount = c.ProductsForClient.Count,
                    CompanyName = c.CompanyName,
                    Address = c.Address,
                    Phone = c.Phone,
                    ContactPerson = c.ContactPerson
                })
                .ToListAsync();
        }
    }
}