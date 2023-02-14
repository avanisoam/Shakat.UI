using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class MaterialTypeInfo
    {
        [Inject]
        public IMaterialTypeInfoService MaterialTypeInfoService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<MaterialTypeInfoDto> materialTypeInfoDtos { get; set; } = new List<MaterialTypeInfoDto>();

        public MaterialTypeInfoDto? editItem { get; set; }

        public MaterialTypeInfoDto newMaterialTypeInfoObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            materialTypeInfoDtos = await MaterialTypeInfoService.GetAll();
        }

        public async Task AddItem()
        {
            await MaterialTypeInfoService.Create(newMaterialTypeInfoObject);

            newMaterialTypeInfoObject = new();

            materialTypeInfoDtos = await MaterialTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/materialtypeInfo");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await MaterialTypeInfoService.Update(editItem);
            }

            materialTypeInfoDtos = await MaterialTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/materialtypeInfo");

        }

        public async Task DeleteItem(int id)
        {
            await MaterialTypeInfoService.Delete(id);

            materialTypeInfoDtos = await MaterialTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/materialtypeInfo");
        }
    }
}
