using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Dtos.Product
{
    public class DtoGetProduct
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
