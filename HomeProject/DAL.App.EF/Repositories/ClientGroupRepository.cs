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
using ClientGroup = DAL.App.DTO.ClientGroup;

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
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var res = await RepositoryDbSet
                .Include(c => c.Name)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Description)
                .ThenInclude(t => t.Translations)
                .Select(c => new 
                {
                    Id = c.Id,
                    Name = c.Name,
                    Translations = c.Name.Translations,
                    Description = c.Description,
//                    Translations = c.Description.Translations,
                    DiscountPercent = c.DiscountPercent
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new ClientGroup()
            {
                Id = c.Id,
                Name = c.Name.Translate(),
                Description = c.Description.Translate(),
                DiscountPercent = c.DiscountPercent
                     
            }).ToList();
            return resultList;
        }

        public override async Task<DAL.App.DTO.ClientGroup> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var clientGroup = await RepositoryDbSet.FindAsync(id);

            if (clientGroup != null)
            {
                await RepositoryDbContext.Entry(clientGroup)
                    .Reference(c => c.Name)
                    .LoadAsync();
                await RepositoryDbContext.Entry(clientGroup.Name)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(clientGroup)
                    .Reference(c => c.Description)
                    .LoadAsync();
                await RepositoryDbContext.Entry(clientGroup.Description)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            
            return ClientGroupMapper.MapFromDomain(clientGroup);
        }
        

        public virtual async Task<List<ClientGroupWithClientCount>> GetAllWithClientCountAsync()
        {           
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(c => c.Name)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Description)
                .ThenInclude(t => t.Translations)
                .Select(c => new 
                {
                    Id = c.Id,
                    Name = c.Name,
                    Translations = c.Name.Translations,
                    Description = c.Description,
                    DescriptionTranslations = c.Description.Translations,
                    DiscountPercent = c.DiscountPercent,
                    ClientCount = c.Clients.Count
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new ClientGroupWithClientCount()
            {
                Id = c.Id,
                Name = c.Name.Translate(),
                Description = c.Description.Translate(),
                DiscountPercent = c.DiscountPercent,
                ClientCount = c.ClientCount
                     
            }).ToList();
            return resultList;

        }
        public override ClientGroup Update(ClientGroup entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.Name)
                .ThenInclude(t => t.Translations)
                .Include(m => m.Description)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Name.SetTranslation(entity.Name);
            entityInDb.Description.SetTranslation(entity.Description);

            return entity;
        }

    }
}