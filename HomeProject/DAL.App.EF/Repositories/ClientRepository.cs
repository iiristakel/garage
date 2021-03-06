using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                .ThenInclude(p => p.Name)
                .ThenInclude(t => t.Translations)
                .Include(p => p.ClientGroup)
                .ThenInclude(p => p.Description)
                .ThenInclude(t => t.Translations)
                .Include(p => p.ProductsForClient) 
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductName)
                .ThenInclude(p => p.Translations)
                .Include(p => p.ProductsForClient) 
                .ThenInclude(p => p.ProductServices)
                .ThenInclude(p => p.Description)
                .ThenInclude(p => p.Translations)    
                .Include(p => p.Bills)
                .ThenInclude(p => p.Comment)
                .ThenInclude(p => p.Translations)
                .Select(e => ClientMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<List<DAL.App.DTO.Client>> AllForClientGroupAsync(int? clientGroupId)
        {
            return await RepositoryDbSet
                .Include(p => p.ClientGroup)
                .Where(p => p.ClientGroupId == clientGroupId)
                .Select(e => ClientMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        

        public override async Task<DAL.App.DTO.Client> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var client = await RepositoryDbSet.FindAsync(id);

            if (client != null)
            {
                await RepositoryDbContext.Entry(client)
                    .Reference(c => c.ClientGroup)
                    .LoadAsync();
                await RepositoryDbContext.Entry(client.ClientGroup)
                    .Reference(c => c.Name)
                    .LoadAsync();
                await RepositoryDbContext.Entry(client.ClientGroup)
                    .Reference(c => c.Description)
                    .LoadAsync();
                await RepositoryDbContext.Entry(client.ClientGroup.Name)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(client.ClientGroup.Description)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();

                await RepositoryDbContext.Entry(client)
                    .Collection(c => c.ProductsForClient)
                    .LoadAsync();
                
                foreach (var productForClient in client.ProductsForClient)
                {
                    await RepositoryDbContext.Entry(productForClient)
                        .Reference(b => b.Product)
                        .LoadAsync();
                    await RepositoryDbContext.Entry(productForClient.Product)
                        .Reference(b => b.ProductName)
                        .LoadAsync();
                    await RepositoryDbContext.Entry(productForClient.Product.ProductName)
                        .Collection(b => b.Translations)
                        .Query()
                        .Where(t => t.Culture == culture)
                        .LoadAsync();
                }
                
                await RepositoryDbContext.Entry(client)
                    .Collection(c => c.Bills)
                    .LoadAsync();
                
                foreach (var bill in client.Bills)
                {
                    await RepositoryDbContext.Entry(bill)
                        .Reference(b => b.Comment)
                        .LoadAsync();
                    await RepositoryDbContext.Entry(bill.Comment)
                        .Collection(b => b.Translations)
                        .Query()
                        .Where(t => t.Culture == culture)
                        .LoadAsync();
                }
            }

            return ClientMapper.MapFromDomain(client);
        }

        public async Task<List<ClientWithProductsCount>> GetAllWithProductsCountAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.ClientGroup)
                .ThenInclude(p => p.Name)
                .ThenInclude(t => t.Translations)
                .Include(p => p.ClientGroup)
                .ThenInclude(p => p.Description)
                .ThenInclude(t => t.Translations)

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