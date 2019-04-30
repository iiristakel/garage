using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Bill
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public decimal ArrivalFee { get; set; }
        public decimal SumWithoutTaxes { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? FinalSum { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [MinLength(1)]
        [MaxLength(64)]
        [Required]
        public string InvoiceNr { get; set; }

        public string Comment { get; set; }
    }
}