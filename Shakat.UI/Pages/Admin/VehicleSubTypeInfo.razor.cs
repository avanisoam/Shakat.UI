using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class VehicleSubTypeInfo
    {
        [Inject]
        public IVehicleSubTypeInfoService VehicleSubTypeInfoService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<VehicleSubTypeInfoDto> vehicleSubTypeInfoDtos { get; set; } = new List<VehicleSubTypeInfoDto>();

        public VehicleSubTypeInfoDto? editItem { get; set; }

        public VehicleSubTypeInfoDto newVehicleSubTypeInfoObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            vehicleSubTypeInfoDtos = await VehicleSubTypeInfoService.GetAll();
        }

        public async Task AddItem()
        {
            await VehicleSubTypeInfoService.Create(newVehicleSubTypeInfoObject);

            newVehicleSubTypeInfoObject = new();

            vehicleSubTypeInfoDtos = await VehicleSubTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehiclesubtypeInfo");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await VehicleSubTypeInfoService.Update(editItem);
            }

            vehicleSubTypeInfoDtos = await VehicleSubTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehiclesubtypeInfo");

        }

        public async Task DeleteItem(int id)
        {
            await VehicleSubTypeInfoService.Delete(id);

            vehicleSubTypeInfoDtos = await VehicleSubTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehiclesubtypeInfo");
        }
    }
}
