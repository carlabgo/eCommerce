using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataModel.Models
{
    [Table("user")]
    public class User : BaseModel
    {
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; }
        [Required]
        [Column("role_id")]
        public long RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
