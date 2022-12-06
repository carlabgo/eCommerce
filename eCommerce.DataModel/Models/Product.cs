using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataModel.Models
{
    [Table("product")]
    public class Product : BaseModel
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("category_id")]
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("cost")]
        public decimal Cost { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("description")]
        public string? Description { get; set; }


    }
}
