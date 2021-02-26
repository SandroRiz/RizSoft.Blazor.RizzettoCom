using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RizSoft.Blazor.Models;

namespace RizSoft.Blazor.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
