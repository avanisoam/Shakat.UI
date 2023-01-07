
using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class RouteInfo
    {
        [Inject]
        public IRouteInfoService RouteInfoService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<RouteInfoDto> routeInfoDtos { get; set; } = new List<RouteInfoDto>();

        public RouteInfoDto? editItem { get; set; }

        public RouteInfoDto newRouteInfoObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            routeInfoDtos = await RouteInfoService.GetAll();
        }

        public async Task AddItem()
        {
            await RouteInfoService.Create(newRouteInfoObject);

            newRouteInfoObject = new();

            routeInfoDtos = await RouteInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/routeInfoDto");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await RouteInfoService.Update(editItem);
            }

            routeInfoDtos = await RouteInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/routeInfoDto");

        }

        public async Task DeleteItem(int id)
        {
            await RouteInfoService.Delete(id);

            routeInfoDtos = await RouteInfoService.GetAll();

            MyNavigationManager.NavigateTo("admin/routeInfoDto");
        }

    }
}

