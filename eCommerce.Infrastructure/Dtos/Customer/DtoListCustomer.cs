﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Dtos.Customer
{
    public class DtoListCustomer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DNI { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
