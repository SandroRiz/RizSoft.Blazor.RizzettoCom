using Microsoft.AspNetCore.Components;
using RizSoft.Blazor.Models;
using RizSoft.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RizSoft.Blazor.Server.UI.Pages
{
    public class ProductList1Base : ComponentBase
    {
        [Inject] IProductService ProductService { get; set; }
        [Inject] ICategoryService CategoryService { get; set; }

        protected IEnumerable<Product> Products;
        protected IEnumerable<Category> Categories;

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.ListAsync();
            Products = await ProductService.ListAsync();
        }
    }
}
