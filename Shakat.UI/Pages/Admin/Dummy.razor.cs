
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

        public string Value { get; set; }

        public EventCallback<string> ValueChanged { get; set; }

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

        public Task OnValueChanged(ChangeEventArgs e)
        {
            Value = e.Value.ToString();

            newDummyObject.DummyId = Convert.ToInt32(Value);

            return ValueChanged.InvokeAsync(Value);
        }

    }
}

