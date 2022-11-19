using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataModel.Models
{
    public class BaseTypification : BaseModel
    {
        [Required]
        [Column("label")]
        public string Label { get; set; }
        [Required]
        [Column("code")]
        public string Code { get; set; }
    }
}
