using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class DeviceHistory
    {
        [Inject]
        public IDeviceHistoryService DeviceHistoryService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<DeviceHistoryDto> deviceHistoryDtos { get; set; } = new List<DeviceHistoryDto>();

        public DeviceHistoryDto? editItem { get; set; }

        public DeviceHistoryDto newDeviceHistoryObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            deviceHistoryDtos = await DeviceHistoryService.GetAll();
        }

        public async Task AddItem()
        {
            await DeviceHistoryService.Create(newDeviceHistoryObject);

            newDeviceHistoryObject = new();

            deviceHistoryDtos = await DeviceHistoryService.GetAll();

            MyNavigationManager.NavigateTo("admin/deviceHistory");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await DeviceHistoryService.Update(editItem);
            }

            deviceHistoryDtos = await DeviceHistoryService.GetAll();

            MyNavigationManager.NavigateTo("admin/deviceHistory");

        }

        public async Task DeleteItem(int id)
        {
            await DeviceHistoryService.Delete(id);

            deviceHistoryDtos = await DeviceHistoryService.GetAll();

            MyNavigationManager.NavigateTo("admin/deviceHistory");
        }

    }
}
