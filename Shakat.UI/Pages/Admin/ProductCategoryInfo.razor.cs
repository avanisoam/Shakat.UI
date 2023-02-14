using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class ProductCategoryInfo
    {
        [Inject]
        public IProductCategoryInfoService ProductCategoryInfoService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<ProductCategoryInfoDto> productCategoryInfoDtos { get; set; } = new List<ProductCategoryInfoDto>();

        public ProductCategoryInfoDto? editItem { get; set; }

        public ProductCategoryInfoDto newProductCategoryInfoObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            productCategoryInfoDtos = await ProductCategoryInfoService.GetAll();
        }

        public async Task AddItem()
        {
            await ProductCategoryInfoService.Create(newProductCategoryInfoObject);

            newProductCategoryInfoObject = new();

            productCategoryInfoDtos = await ProductCategoryInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/productCategoryInfo");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await ProductCategoryInfoService.Update(editItem);
            }

            productCategoryInfoDtos = await ProductCategoryInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/productCategoryInfo");
        }

        public async Task DeleteItem(int id)
        {
            await ProductCategoryInfoService.Delete(id);

            productCategoryInfoDtos = await ProductCategoryInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/productCategoryInfo");

        }

    }

}


