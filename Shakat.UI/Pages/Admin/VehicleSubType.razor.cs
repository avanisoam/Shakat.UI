using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class VehicleSubType
    {
        [Inject]
        public IVehicleSubTypeService VehicleSubTypeService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<VehicleSubTypeDto> SubVehicles { get; set; } = new List<VehicleSubTypeDto>();

        public VehicleSubTypeDto? editItem { get; set; }

        public VehicleSubTypeDto newSubTypeObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            SubVehicles = await VehicleSubTypeService.GetAll();
        }

        public async Task AddItem()
        {
            await VehicleSubTypeService.Create(newSubTypeObject);

            newSubTypeObject = new();

            SubVehicles = await VehicleSubTypeService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehiclesubtype");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await VehicleSubTypeService.UpdateSubType(editItem);
            }

            SubVehicles = await VehicleSubTypeService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehiclesubtype");

        }

        public async Task DeleteItem(int id)
        {
            await VehicleSubTypeService.Delete(id);

            SubVehicles = await VehicleSubTypeService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehiclesubtype");
        }

    }
}
