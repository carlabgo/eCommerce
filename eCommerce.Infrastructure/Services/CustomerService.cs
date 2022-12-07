using eCommerce.DataModel;
using eCommerce.DataModel.Models;
using eCommerce.Infrastructure.Common;
using eCommerce.Infrastructure.Dtos.Customer;
using eCommerce.Infrastructure.OperationResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
{
    public class CustomerService
    {
        internal readonly DBContext _context;

        public CustomerService(DBContext context)
        {
            _context = context;
        }

        public async Task<OperationResponse<DtoGetCustomer>> GetById(long id)
        {
            Customer customer = await _context
                .Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);

            var dto = new DtoGetCustomer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,  
                DNI = customer.DNI,
                Email = customer.Email,
                Address = customer.Address,
                ZipCode = customer.ZipCode,
                PhoneNumber = customer.PhoneNumber,
            };
            return new OperationResponse<DtoGetCustomer>(dto);
        }

        public async Task<OperationResponse<long>> Add(DtoAddCustomer createrequest)
        {
            Customer newCustomer = new()
            {
                FirstName = createrequest.FirstName,
                LastName = createrequest.LastName,
                DNI = createrequest.DNI,
                Email=createrequest.Email,
                Address=createrequest.Address,
                ZipCode=createrequest.ZipCode,
                PhoneNumber=createrequest.PhoneNumber,

            };
            var customer = await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return new OperationResponse<long>(customer.Entity.Id);
        }

        public async Task<OperationResponse<long>> Update(DtoEditCustomer updaterequest)
        {

            Customer customer = await _context
                                    .Customers
                                    .FirstOrDefaultAsync(p => p.Id == updaterequest.Id);

            if (customer == null) return new OperationResponse<long>(updaterequest.Id, false);

            customer.Id = updaterequest.Id;
            customer.FirstName = updaterequest.FirstName;
            customer.LastName = updaterequest.LastName;
            customer.DNI = updaterequest.DNI;
            customer.Email = updaterequest.Email;
            customer.Address = updaterequest.Address;
            customer.ZipCode = updaterequest.ZipCode;
            customer.PhoneNumber = updaterequest.PhoneNumber;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return new OperationResponse<long>(updaterequest.Id);
        }
        public async Task<OperationResponse<DtoPagination<DtoListCustomer>>> ListCustomers(string filter, int pageSize, int page, CancellationToken ct = default)
        {
            var query = _context
                .Customers
                .AsNoTracking()
                .Where(p => p.Email.ToLower().Contains(filter ?? ""));

            var count = await query.CountAsync().ConfigureAwait(false);

            var list = (await query.OrderBy(p => p.FirstName)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(ct)
                .ConfigureAwait(false))
                .Select(c => new DtoListCustomer
                {
                    Id = c.Id,
                   FirstName = c.FirstName,
                   LastName= c.LastName,
                   DNI= c.DNI,
                   Email = c.Email,
                   Address = c.Address,
                   ZipCode = c.ZipCode,
                   PhoneNumber  = c.PhoneNumber
                });

            return new OperationResponse<DtoPagination<DtoListCustomer>>(new DtoPagination<DtoListCustomer>()
            {
                Data = list,
                PageSize = pageSize,
                TotalCount = count
            });
        }

    }
}

