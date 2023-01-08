
using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{
    public partial class Dummy
    {
        [Inject]
        public IDummyService DummyService { get; set; }

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public IEnumerable<DummyDto> dummyDtos { get; set; } = new List<DummyDto>();

        public DummyDto? editItem { get; set; }

        public DummyDto newDummyObject { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            dummyDtos = await DummyService.GetAll();
        }

        public async Task AddItem()
        {
            await DummyService.Create(newDummyObject);

            newDummyObject = new();

            dummyDtos = await DummyService.GetAll();

            MyNavigationManager.NavigateTo("admin/dummyDto");
        }

        public async Task UpdateItem()
        {
            if (editItem is not null)
            {
                await DummyService.Update(editItem);
            }

            dummyDtos = await DummyService.GetAll();

            MyNavigationManager.NavigateTo("admin/dummyDto");

        }

        public async Task DeleteItem(int id)
        {
            await DummyService.Delete(id);

            dummyDtos = await DummyService.GetAll();

            MyNavigationManager.NavigateTo("admin/dummyDto");
        }

    }
}

