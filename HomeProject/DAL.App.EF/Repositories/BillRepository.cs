using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BillRepository : BaseRepository<Bill, AppDbContext>, IBillRepository
    {
        public BillRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }


        public override async Task<List<Bill>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Client)
                .ToListAsync();
        }
        
        public override async Task<Bill> FindAsync(params object[] id)
        {
            var bill = await base.FindAsync(id);

            if (bill != null)
            {
                await RepositoryDbContext.Entry(bill).Reference(c => c.Client).LoadAsync();
            }
            
            return bill;
        }

        public virtual async Task<List<BillsDTO>> GetAllWithPaymentsCountAsync()
        {
            return await RepositoryDbSet
                .Select(c => new BillsDTO()
                {
                    Id = c.Id,
                    Client = c.Client,
                    ClientId = c.ClientId,
                    BillLines = c.BillLines,
                    PaymentsCount = c.Payments.Count,
                    ArrivalFee = c.ArrivalFee,
                    SumWithoutTaxes = c.Sum,
                    TaxPercent = c.TaxPercent,
                    FinalSum = c.Sum * (1 + (c.TaxPercent / 100)),
                    DateTime = c.DateTime,
                    InvoiceNr = c.InvoiceNr,
                    Comment = c.Comment
                })
                .ToListAsync();
        }
    }
}