using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WorkObject = DAL.App.DTO.WorkObject;

namespace DAL.App.EF.Repositories
{
    public class WorkObjectRepository
        : BaseRepository<DAL.App.DTO.WorkObject, Domain.WorkObject,
            AppDbContext>, IWorkObjectRepository
    {
        public WorkObjectRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new WorkObjectMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.WorkObject>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .Include(p => p.AppUsersOnObject)
                .ThenInclude(p => p.AppUser)
                .Include(p => p.ProductsServices)
                .ThenInclude(p => p.Description)
                .ThenInclude(p => p.Translations)
                .Include(p => p.Bills)
                .ThenInclude(p=> p.Comment)
                .ThenInclude(p => p.Translations)
                .Include(p => p.Bills)
                .ThenInclude(p=> p.BillLines)
                .Select(e => WorkObjectMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public override async Task<DAL.App.DTO.WorkObject> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var workObject = await RepositoryDbSet.FindAsync(id);

            if (workObject != null)
            {
                await RepositoryDbContext.Entry(workObject)
                    .Reference(c => c.Client)
                    .LoadAsync();
//                await RepositoryDbContext.Entry(workObject.Client)
//                    .Collection(c => c.Bills)
//                    .LoadAsync();
//                
//                foreach (var bill in workObject.Bills)
//                {
//                    await RepositoryDbContext.Entry(bill)
//                        .Reference(b => b.Comment)
//                        .LoadAsync();
//
//                    await RepositoryDbContext.Entry(bill.Comment)
//                        .Collection(b => b.Translations)
//                        .Query()
//                        .Where(t => t.Culture == culture)
//                        .LoadAsync();
//                }
//
//                await RepositoryDbContext.Entry(workObject)
//                    .Collection(c => c.AppUsersOnObject)
//                    .LoadAsync();
//                
//                foreach (var appUserOnObject in workObject.AppUsersOnObject)
//                {
//                    await RepositoryDbContext.Entry(appUserOnObject)
//                        .Reference(b => b.AppUser)
//                        .LoadAsync();
//
//                }
//
//                await RepositoryDbContext.Entry(workObject)
//                    .Collection(c => c.ProductsServices)
//                    .LoadAsync();
//
//
//                foreach (var service in workObject.ProductsServices)
//                {
//                    await RepositoryDbContext.Entry(service)
//                        .Reference(b => b.Description)
//                        .LoadAsync();
//
//                    await RepositoryDbContext.Entry(service.Description)
//                        .Collection(b => b.Translations)
//                        .Query()
//                        .Where(t => t.Culture == culture)
//                        .LoadAsync();
//                }

            }
                return WorkObjectMapper.MapFromDomain(workObject);
            
        }

        public async Task<List<DAL.App.DTO.WorkObject>> AllForUserAsync(int userId)
            {
                return await RepositoryDbSet
                    .Include(p => p.Client)
                    .Include(p => p.AppUsersOnObject)
                    .ThenInclude(p => p.AppUser)
                    .Include(p => p.ProductsServices)
                    .ThenInclude(p => p.Description)
                    .ThenInclude(p => p.Translations)
                    .Include(p => p.Bills)
                    .ThenInclude(p=> p.Comment)
                    .ThenInclude(p => p.Translations)
                    .Include(p => p.Bills)
                    .ThenInclude(p=> p.BillLines)
                    .Where(q => q.AppUsersOnObject.Any(p => p.AppUserId == userId))
                    .Select(e => WorkObjectMapper.MapFromDomain(e))
                    .ToListAsync();
            }


            public async Task<WorkObject> FindForUserAsync(int id, int userId)
            {
                var workObject = await RepositoryDbSet
                    .Include(c => c.Client)
                    .Include(q => q.Bills)

                    .Include(p => p.AppUsersOnObject)
                    .ThenInclude(p => p.AppUser)

                    .Include(p => p.ProductsServices)
                    .ThenInclude(p => p.Description)
                    .ThenInclude(p => p.Translations)

                    .Include(p => p.ProductsServices)
                    .ThenInclude(p => p.ProductForClient)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.ProductName)
                    .ThenInclude(p => p.Translations)
                    .FirstOrDefaultAsync(m => m.Id == id && m.AppUsersOnObject.Any(q => q.AppUserId == userId));

                return WorkObjectMapper.MapFromDomain(workObject);
            }

            public async Task<bool> BelongsToUserAsync(int id, int userId)
            {
                return await RepositoryDbSet
                    .AnyAsync(c => c.Id == id && c.AppUsersOnObject.Any(q => q.AppUserId == userId));
            }
        }
    }