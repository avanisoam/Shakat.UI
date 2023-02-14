using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class VehicleTypeInfo
    {
        [Inject]
        public IVehicleTypeInfoService VehicleTypeInfoService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<VehicleTypeInfoDto> vehicleTypeInfoDtos { get; set; } = new List<VehicleTypeInfoDto>();

        public VehicleTypeInfoDto? editItem { get; set; }

        public VehicleTypeInfoDto newVehicleTypeInfoObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            vehicleTypeInfoDtos = await VehicleTypeInfoService.GetAll();
        }

        public async Task AddItem()
        {
            await VehicleTypeInfoService.Create(newVehicleTypeInfoObject);

            newVehicleTypeInfoObject = new();

            vehicleTypeInfoDtos = await VehicleTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehicletypeInfo");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await VehicleTypeInfoService.Update(editItem);
            }

            vehicleTypeInfoDtos = await VehicleTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehicletypeInfo");

        }

        public async Task DeleteItem(int id)
        {
            await VehicleTypeInfoService.Delete(id);

            vehicleTypeInfoDtos = await VehicleTypeInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehicletypeInfo");
        }
    }
}
