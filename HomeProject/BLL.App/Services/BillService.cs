using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class BillService 
        : BaseEntityService<BLL.App.DTO.Bill, DAL.App.DTO.Bill,
            IAppUnitOfWork>, IBillService
    {
        public BillService(IAppUnitOfWork uow) : base(uow, new BillMapper())
        {
            ServiceRepository = Uow.Bills;
        }

        public override async Task<Bill> FindAsync(params object[] id)
        {
            var bill = await Uow.Bills.FindAsync(id);

            if (bill != null)
            {
                var billLines = await Uow.BillLines.AllForBillAsync(bill.Id);

                bill.SumWithoutTaxes = bill.ArrivalFee;

                foreach (var billLine in billLines)
                {
                    bill.SumWithoutTaxes += billLine.SumWithDiscount;
                }

                bill.FinalSum = bill.SumWithoutTaxes * 100 / (100 - bill.TaxPercent);

                
            }
            return BillMapper.MapFromDAL(bill);

        }
        
        public override async Task<List<Bill>> AllAsync()
        {
            var res = (await Uow.Bills.AllAsync())
                .Select(c => new Bill()
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    Client = ClientMapper.MapFromDAL(c.Client),
                    ArrivalFee = c.ArrivalFee,
                    SumWithoutTaxes = c.SumWithoutTaxes,
                    TaxPercent = c.TaxPercent,
                    FinalSum = c.FinalSum,
                    DateTime = c.DateTime,
                    InvoiceNr = c.InvoiceNr,
                    Comment = c.Comment,
                    WorkObjectId = c.WorkObjectId,
                    WorkObject = WorkObjectMapper.MapFromDAL(c.WorkObject)
                    
                }).ToList();
            
            foreach (var bill in res)
            {
                var billLines = await Uow.BillLines.AllForBillAsync(bill.Id);
                
                bill.SumWithoutTaxes = bill.ArrivalFee;
                
                foreach (var billLine in billLines)
                {
                    bill.SumWithoutTaxes += billLine.SumWithDiscount;
                }

                bill.FinalSum = bill.SumWithoutTaxes * 100 / (100 - bill.TaxPercent);
            }

            return res;
        }

        public async Task<List<Bill>> AllForClientAsync(int? clientId)
        {

            var res = (await Uow.Bills
                    .AllForClientAsync(clientId))
                .Select(c => new Bill()
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    Client = ClientMapper.MapFromDAL(c.Client),
                    ArrivalFee = c.ArrivalFee,
                    SumWithoutTaxes = c.SumWithoutTaxes,
                    TaxPercent = c.TaxPercent,
                    FinalSum = c.FinalSum,
                    DateTime = c.DateTime,
                    InvoiceNr = c.InvoiceNr,
                    Comment = c.Comment,
                    WorkObjectId = c.WorkObjectId,
                    WorkObject = WorkObjectMapper.MapFromDAL(c.WorkObject)
                    
                }).ToList();
            
            foreach (var bill in res)
            {
                var billLines = await Uow.BillLines.AllForBillAsync(bill.Id);
                
                bill.SumWithoutTaxes = bill.ArrivalFee;
                
                foreach (var billLine in billLines)
                {
                    bill.SumWithoutTaxes += billLine.SumWithDiscount;
                }

                bill.FinalSum = bill.SumWithoutTaxes * 100 / (100 - bill.TaxPercent);

            }

            return res;
        }
        
        public async Task<List<Bill>> AllForWorkObjectAsync(int workObjectId)
        {

            var res = (await Uow.Bills
                    .AllForWorkObjectAsync(workObjectId))
                .Select(c => new Bill()
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    Client = ClientMapper.MapFromDAL(c.Client),
                    ArrivalFee = c.ArrivalFee,
                    SumWithoutTaxes = c.SumWithoutTaxes,
                    TaxPercent = c.TaxPercent,
                    FinalSum = c.FinalSum,
                    DateTime = c.DateTime,
                    InvoiceNr = c.InvoiceNr,
                    Comment = c.Comment,
                    WorkObjectId = c.WorkObjectId,
                    WorkObject = WorkObjectMapper.MapFromDAL(c.WorkObject)
                    
                }).ToList();
            
            foreach (var bill in res)
            {
                var billLines = await Uow.BillLines.AllForBillAsync(bill.Id);
                
                bill.SumWithoutTaxes = bill.ArrivalFee;
                
                foreach (var billLine in billLines)
                {
                    bill.SumWithoutTaxes += billLine.SumWithDiscount;
                }

                bill.FinalSum = bill.SumWithoutTaxes * 100 / (100 - bill.TaxPercent);

            }

            return res;
        }


        public async Task<List<Bill>> AllForUserAsync(int userId)
        {
            return (await Uow.Bills
                    .AllForUserAsync(userId))
                .Select(e => BillMapper
                    .MapFromDAL(e)).ToList();
        }

        public async Task<Bill> FindForUserAsync(int id, int userId)
        {
            return BillMapper.MapFromDAL( await Uow.Bills.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Bills.BelongsToUserAsync(id, userId);
        }

        
    }
}