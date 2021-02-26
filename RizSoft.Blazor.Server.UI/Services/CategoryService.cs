using Microsoft.EntityFrameworkCore;
using RizSoft.Blazor.Data;
using RizSoft.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RizSoft.Blazor.Services
{
    public class CategoryService : ICategoryService

    {

        private readonly AcmeDbContext _acmeDbContext;

        public CategoryService(AcmeDbContext acmeDbContext)
        {
            _acmeDbContext = acmeDbContext;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _acmeDbContext.Categories.ToListAsync();
        }
    }
}
