using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Common
{
    public class DtoPagination<T>
    {
        public IEnumerable<T> Data { get; set;}
        public long TotalCount { get; set;}
        public int PageSize { get; set;}
    }
}
