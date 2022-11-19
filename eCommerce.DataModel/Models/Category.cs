using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataModel.Models
{
    [Table("category")]
    public class Category : BaseModel
    {
        [Required]
        [Column("description")]
        public string Description { get; set; }
    }
}
