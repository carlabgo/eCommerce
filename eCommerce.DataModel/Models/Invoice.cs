using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataModel.Models
{
    [Table("invoice")]
    public class Invoice : BaseModel
    {
        [Column("costumer_id")]
        public long CostumerId { get; set; }
        [ForeignKey(nameof(CostumerId))]
        public Customer Costumer { get; set; }
        [Required]
        [Column("invoice_number")]
        public long InvoiceNumber { get; set; }
        [Column("observation")]
        public string Observation { get; set; }
        [Required]
        [Column("date_time")]
        public DateTime DateTime { get; set; }
        [Column("total")]
        public decimal Total { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set;}

    }
}
