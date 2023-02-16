using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class DeviceInfo
    {

        [Inject]
        public IDeviceInfoService DeviceInfoService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<DeviceInfoDto> deviceInfoDtos { get; set; } = new List<DeviceInfoDto>();

        public DeviceInfoDto? editItem { get; set; }

        public DeviceInfoDto newDeviceInfoObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            deviceInfoDtos = await DeviceInfoService.GetAll();
        }

        public async Task AddItem()
        {
            await DeviceInfoService.Create(newDeviceInfoObject);

            newDeviceInfoObject = new();

            deviceInfoDtos = await DeviceInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/deviceInfo");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await DeviceInfoService.Update(editItem);
            }

            deviceInfoDtos = await DeviceInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/deviceInfo");

        }

        public async Task DeleteItem(int id)
        {
            await DeviceInfoService.Delete(id);

            deviceInfoDtos = await DeviceInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/deviceInfo");
        }

    }
}
