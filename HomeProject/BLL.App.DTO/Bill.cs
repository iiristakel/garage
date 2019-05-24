using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO
{
    public class Bill
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        [Display(Name = nameof(Client), ResourceType = typeof(Resources.Domain.Bill))]
        public Client Client { get; set; }
        
        public int WorkObjectId { get; set; }
        [Display(Name = nameof(WorkObject), ResourceType = typeof(Resources.Domain.Bill))]
        public WorkObject WorkObject { get; set; }
        
//        public ICollection<BillLine> BillLines { get; set; }
//        
//        public ICollection<Payment> Payments { get; set; }

        [Display(Name = nameof(ArrivalFee), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal ArrivalFee { get; set; }

        [Display(Name = nameof(SumWithoutTaxes), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal? SumWithoutTaxes { get; set; }

        [Display(Name = nameof(TaxPercent), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal? TaxPercent { get; set; }

        [Display(Name = nameof(FinalSum), ResourceType = typeof(Resources.Domain.Bill))]
        public decimal? FinalSum { get; set; }

        [Display(Name = nameof(DateTime), ResourceType = typeof(Resources.Domain.Bill))]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [MaxLength(64, ErrorMessageResourceName = "ErrorMessageMaxLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(InvoiceNr), ResourceType = typeof(Resources.Domain.Bill))]
        public string InvoiceNr { get; set; }

        [Display(Name = nameof(Comment), ResourceType = typeof(Resources.Domain.Bill))]
        public string Comment { get; set; }
    }
}