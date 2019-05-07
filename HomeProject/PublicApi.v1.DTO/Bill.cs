using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class Bill
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        public ICollection<BillLine> BillLines { get; set; }
        

        public decimal ArrivalFee { get; set; }

        public decimal SumWithoutTaxes { get; set; }

        public decimal? TaxPercent { get; set; }

        public decimal? FinalSum { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string InvoiceNr { get; set; }

        public string Comment { get; set; }
    }
}