
using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class Shipment
    {
        [Inject]
        public IShipmentService ShipmentService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<ShipmentDto> shipmentDtos { get; set; } = new List<ShipmentDto>();

        public ShipmentDto? editItem { get; set; }

        public ShipmentDto newShipmentObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            shipmentDtos = await ShipmentService.GetAll();
        }

        public async Task AddItem()   //Not WOrking
        {
            await ShipmentService.Create(newShipmentObject);

            newShipmentObject = new();

            shipmentDtos = await ShipmentService.GetAll();

            MyNavigationManager.NavigateTo("admin/shipment");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await ShipmentService.Update(editItem);
            }

            shipmentDtos = await ShipmentService.GetAll();

            MyNavigationManager.NavigateTo("admin/shipment");

        }

        public async Task DeleteItem(int id)
        {
            await ShipmentService.Delete(id);

            shipmentDtos = await ShipmentService.GetAll();

            MyNavigationManager.NavigateTo("admin/shipment");
        }

    }
}

