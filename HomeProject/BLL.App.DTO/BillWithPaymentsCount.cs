using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class BillWithPaymentsCount 
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        [Display(Name = nameof(Client), ResourceType = typeof(Resources.Domain.Bill))]
        public Client Client { get; set; }

        [Display(Name = nameof(InvoiceNr), ResourceType = typeof(Resources.Domain.Bill))]
        public string InvoiceNr { get; set; }

        [Display(Name = nameof(DateTime), ResourceType = typeof(Resources.Domain.Bill))]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        //        public ICollection<BillLine> BillLines { get; set; }

        [Display(Name = nameof(PaymentsCount), ResourceType = typeof(Resources.Domain.Bill))]
        public int PaymentsCount { get; set; }

        [Display(Name = nameof(ArrivalFee), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal ArrivalFee { get; set; }

        [Display(Name = nameof(SumWithoutTaxes), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal SumWithoutTaxes { get; set; }

        [Display(Name = nameof(TaxPercent), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal? TaxPercent { get; set; }

        [Display(Name = nameof(FinalSum), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal? FinalSum { get; set; }

        [Display(Name = nameof(Comment), ResourceType = typeof(Resources.Domain.Bill))]
        public string Comment { get; set; }
    }
}