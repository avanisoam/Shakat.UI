using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class VehicleType
    {
        [Inject]
        public IVehicleTypeService VehicleTypeService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<VehicleTypeDto> Vehicles { get; set; } = new List<VehicleTypeDto>();

        public VehicleTypeDto? editItem { get; set; }

        public VehicleTypeDto newTypeObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Vehicles = await VehicleTypeService.GetAll();
        }

        public async Task AddItem()
        {
            await VehicleTypeService.Create(newTypeObject);

            newTypeObject = new();

            Vehicles = await VehicleTypeService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehicletype");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await VehicleTypeService.UpdateSubType(editItem);
            }

            Vehicles = await VehicleTypeService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehicletype");

        }

        public async Task DeleteItem(int id)
        {
            await VehicleTypeService.Delete(id);

            Vehicles = await VehicleTypeService.GetAll();

            MyNavigationManager.NavigateTo("admin/vehicletype");
        }
    }
}
