using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class VehicleSubType
    {
        [Inject]
        public IVehicleSubTypeService VehicleSubTypeService { get; set; }

        public IEnumerable<VehicleSubTypeDto> SubVehicles { get; set; } = new List<VehicleSubTypeDto>();

        protected override async Task OnInitializedAsync()
        {
            SubVehicles = await VehicleSubTypeService.GetAll();
        }
    }
}
