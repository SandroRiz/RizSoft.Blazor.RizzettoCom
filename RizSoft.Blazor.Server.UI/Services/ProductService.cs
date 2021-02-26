using Microsoft.EntityFrameworkCore;
using RizSoft.Blazor.Data;
using RizSoft.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RizSoft.Blazor.Services
{
    public class ProductService : IProductService
    {
        private readonly AcmeDbContext _acmeDbContext;

        public ProductService( AcmeDbContext acmeDbContext)
        {
            _acmeDbContext = acmeDbContext;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _acmeDbContext.Products.OrderBy(x => x.ProductName).ToListAsync();
        }
    }
}
