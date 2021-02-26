using Microsoft.AspNetCore.Components;
using RizSoft.Blazor.Models;
using RizSoft.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RizSoft.Blazor.Server.UI.Pages
{
    public class ProductList2Base : ComponentBase
    {

        [Inject] IProductService ProductService { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }

       
        protected IEnumerable<Category> Categories;

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.ListAsync();
          
        }

        protected async Task<IEnumerable<Product>> LoadDataAsync(CancellationToken token)
        {
            return await ProductService.ListAsync();
        }
    }
}
