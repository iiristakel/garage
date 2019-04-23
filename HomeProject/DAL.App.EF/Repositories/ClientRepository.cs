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
    public class ClientRepository : BaseRepository<Client, AppDbContext>, IClientRepository
    {
        public ClientRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<Client>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.ClientGroup)
                .ToListAsync();
        }
        public override async Task<Client> FindAsync(params object[] id)
        {
            var client = await base.FindAsync(id);

            if (client != null)
            {
                await RepositoryDbContext.Entry(client).Reference(c => c.ClientGroup).LoadAsync();
            }
            
            return client;
        }

        public virtual async Task<List<ClientsDTO>> GetAllWithProductsCountAsync()
        {
            return await RepositoryDbSet
                .Select(c => new ClientsDTO()
                {
                    Id = c.Id,
                    ClientGroup = c.ClientGroup,
                    ClientGroupId = c.ClientGroupId,
                    ProductsForClient = c.ProductsForClient,
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