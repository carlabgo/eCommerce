using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataModel.Models
{
    [Table("customer")]
    public class Customer : BaseModel
    {
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }
        [Required]
        [Column("dni")]
        public string DNI { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("address")]
        public string Address { get; set; }
        [Column("zip_code")]
        public string ZipCode { get; set; }
        [Required]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
