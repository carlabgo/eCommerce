using eCommerce.DataModel;
using eCommerce.DataModel.Models;
using eCommerce.Infrastructure.Common;
using eCommerce.Infrastructure.Dtos.Product;
using eCommerce.Infrastructure.OperationResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
{
    public class ProductService
    {
        internal readonly DBContext _context;

        public ProductService(DBContext context)
        {
            _context = context;
        }

        public async Task<OperationResponse<DtoGetProduct>> GetById(long id)
        {
            Product product = await _context
                .Products
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);

            var dto = new DtoGetProduct()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                IsDeleted = product.IsDeleted,
                Cost = product.Cost,
                Description = product.Description,
                Price = product.Price,
            };
            return new OperationResponse<DtoGetProduct>(dto);
        }

        public async Task<OperationResponse<long>> Add(DtoAddProduct createrequest)
        {
            Product newProduct = new()
            {
                Name = createrequest.Name,
                CategoryId = createrequest.CategoryId,
                IsDeleted = createrequest.IsDeleted,
                Cost = createrequest.Cost,
                Description = createrequest.Description,
                Price = createrequest.Price,
            };
            var product = await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return new OperationResponse<long>(product.Entity.Id);
        }

        public async Task<OperationResponse<long>> Update(DtoEditProduct updaterequest)
        {

            Product product = await _context
                                    .Products
                                    .FirstOrDefaultAsync(p => p.Id == updaterequest.Id && !p.IsDeleted);

            if (product == null) return new OperationResponse<long>(updaterequest.Id, false);

            product.Id = updaterequest.Id;
            product.IsDeleted = updaterequest.IsDeleted;
            product.Cost = updaterequest.Cost;
            product.Description = updaterequest.Description;
            product.Price = updaterequest.Price;
            product.CategoryId = updaterequest.CategoryId;
            product.Name = updaterequest.Name;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return new OperationResponse<long>(updaterequest.Id);
        }
        public async Task<OperationResponse<DtoPagination<DtoListProduct>>> ListProducts(string filter, int pageSize, int page, CancellationToken ct = default)
        {
            var query = _context
                .Products
                .AsNoTracking()
                .Where(p => p.Name.ToLower().Contains(filter ?? ""));

            var count = await query.CountAsync().ConfigureAwait(false);

            var list = (await query.OrderBy(p => p.Name)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(ct)
                .ConfigureAwait(false))
                .Select(c => new DtoListProduct
                {
                    Id = c.Id,
                    Description = c.Description,
                    Cost = c.Cost,
                    Price = c.Price,
                    CategoryId = c.CategoryId,
                    IsDeleted = c.IsDeleted,
                    Name = c.Name,
                });

            return new OperationResponse<DtoPagination<DtoListProduct>>(new DtoPagination<DtoListProduct>()
            {
                Data = list,
                PageSize = pageSize,
                TotalCount = count
            });
        }

    }
}
