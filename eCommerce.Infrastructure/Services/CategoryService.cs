using eCommerce.DataModel;
using eCommerce.DataModel.Models;
using eCommerce.Infrastructure.Common;
using eCommerce.Infrastructure.Dtos.Category;
using eCommerce.Infrastructure.OperationResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
{
    public class CategoryService
    {
        internal readonly DBContext _context;

        public CategoryService(DBContext context)
        { 
            _context = context; 
        }

        public async Task<OperationResponse<DtoGetCategory>> GetById(long id)
        {
            Category category = await _context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);

            var dto = new DtoGetCategory()
            {
                Id = category.Id,
                Description = category.Description,
            };
            return new OperationResponse<DtoGetCategory>(dto);
        }

        public async Task<OperationResponse<long>> Add(DtoAddCategory createrequest)
        {
            Category newCategory = new()
            {
                Description = createrequest.Description,
            };
            var category = await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return new OperationResponse<long>(category.Entity.Id);
        }

        public async Task<OperationResponse<DtoPagination<DtoListCategory>>> ListCategories(string filter, int pageSize, int page, CancellationToken ct = default)
        {
            var query = _context
                .Categories
                .AsNoTracking()
                .Where(p => p.Description.ToLower().Contains(filter ?? ""));

            var count = await query.CountAsync().ConfigureAwait(false);

            var list = (await query.OrderBy(p => p.Description)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(ct)
                .ConfigureAwait(false))
                .Select(c => new DtoListCategory
                {
                    Id = c.Id,
                    Description = c.Description
                });

            return new OperationResponse<DtoPagination<DtoListCategory>>(new DtoPagination<DtoListCategory>()
            {
                Data = list,
                PageSize = pageSize,
                TotalCount = count
            });
        }

    }
}
