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
using Bill = DAL.App.DTO.Bill;

namespace DAL.App.EF.Repositories
{
    public class BillRepository 
        : BaseRepository<DAL.App.DTO.Bill, Domain.Bill,
            AppDbContext>, IBillRepository
    {
        public BillRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new BillMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.Bill>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .Include(p => p.WorkObject)
                .Include(p => p.Comment)
                .ThenInclude(p => p.Translations)
                .Include(p => p.BillLines)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Translations)
                .Include(p => p.Payments)
                .ThenInclude(p => p.PaymentMethod)
                .ThenInclude(p => p.PaymentMethodValue)
                .ThenInclude(p=> p.Translations)
                .Select(e => BillMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task<List<DAL.App.DTO.Bill>> AllForClientAsync(int? clientId)
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .Include(p => p.WorkObject)
                .Include(p => p.Comment)
                .ThenInclude(p => p.Translations)
                .Include(p => p.BillLines)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Translations)
                .Where(p => p.ClientId == clientId)
                .Select(e => BillMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task<List<Bill>> AllForWorkObjectAsync(int workObjectId)
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .Include(p => p.WorkObject)
                .Include(p => p.Comment)
                .ThenInclude(p => p.Translations)
                .Include(p => p.BillLines)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Translations)
                .Where(p => p.WorkObjectId == workObjectId)
                .Select(e => BillMapper.MapFromDomain(e))
                .ToListAsync();
            
        }

        public override async Task<DAL.App.DTO.Bill> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var bill = await RepositoryDbSet.FindAsync(id);

            if (bill != null)
            {
                await RepositoryDbContext.Entry(bill)
                    .Reference(c => c.Client)
                    .LoadAsync();
                await RepositoryDbContext.Entry(bill)
                    .Reference(c => c.WorkObject)
                    .LoadAsync();
                await RepositoryDbContext.Entry(bill)
                    .Collection(c => c.Payments)  // include paymentmethod?
                    .LoadAsync();
                await RepositoryDbContext.Entry(bill)
                    .Collection(c => c.BillLines)
                    .LoadAsync();
                
                foreach (var billLine in bill.BillLines)
                {
                    await RepositoryDbContext.Entry(billLine)
                        .Reference(b => b.Product)
                        .LoadAsync();
                    await RepositoryDbContext.Entry(billLine.Product)
                        .Collection(b => b.Translations)
                        .Query()
                        .Where(t => t.Culture == culture)
                        .LoadAsync();
                }
                await RepositoryDbContext.Entry(bill)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(bill.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            
            return BillMapper.MapFromDomain(bill);
        }


        public async Task<List<Bill>> AllForUserAsync(int userId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var resultList = await RepositoryDbSet
                .Include(c => c.Client)                    
                .Include(c => c.WorkObject)
                .ThenInclude(c => c.AppUsersOnObject)
                .ThenInclude(c => c.AppUser)
                .Include(c => c.BillLines)
                .Include(c => c.Comment)
                .ThenInclude(t => t.Translations)
                .Where(p => p.WorkObject.AppUsersOnObject.Any(q => q.AppUserId == userId))
                .Select(c => BillMapper.MapFromDomain(c))
                .ToListAsync();
//                .Select(c => new
//                {
//                    Id = c.Id,
////                    Client = ClientMapper.MapFromDomain(c.Client),
//                    ClientId = c.ClientId,
//                    ArrivalFee = c.ArrivalFee,
//                    SumWithoutTaxes = c.SumWithOutTaxes,
//                    TaxPercent = c.TaxPercent,
//                    DateTime = c.DateTime,
//                    InvoiceNr = c.InvoiceNr,
//                    Comment = c.Comment,
//                    Translations = c.Comment.Translations
//                })
//                .ToListAsync();
//            
//            var resultList = res.Select(c => new Bill()
//            {
//                Id = c.Id,
////                Client = c.Client,
//                ClientId = c.ClientId,
//                ArrivalFee = c.ArrivalFee,
//                SumWithoutTaxes = c.SumWithoutTaxes,
//                TaxPercent = c.TaxPercent,
//                DateTime = c.DateTime,
//                InvoiceNr = c.InvoiceNr,
//                Comment = c.Comment.Translate()
//                     
//            }).ToList();
            return resultList;

        }

        public async Task<Bill> FindForUserAsync(int id, int userId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            return BillMapper.MapFromDomain(
                await RepositoryDbSet
                    .Include(p => p.Client)
                    .Include(p=> p.WorkObject) //need to include more?
                    .Include(p => p.BillLines)
                    .Include(c => c.Payments)
                    .Include(c => c.Comment)
                    
                    .ThenInclude(t => t.Translations).AsQueryable()
                   
                .FirstOrDefaultAsync(p => p.Id == id && p.WorkObject.AppUsersOnObject.Any(q => q.AppUserId == userId)));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet.AnyAsync(p => p.Id == id && p.WorkObject.AppUsersOnObject
                                                           .Any(q => q.AppUserId == userId));
        }
        
        public override Bill Update(Bill entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(c => c.Payments)
                .Include(c => c.WorkObject)
                .Include(m => m.Comment)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Comment.SetTranslation(entity.Comment);

            return entity;
        }

    }
}