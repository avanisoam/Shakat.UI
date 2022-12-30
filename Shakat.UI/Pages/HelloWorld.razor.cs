using Microsoft.AspNetCore.Components;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages
{
    public partial class HelloWorld
    {
        [Inject]
        public IHelloWorldService HelloWorldService { get; set; }

        public string? Value { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Value = await HelloWorldService.GetString();
        }
    }
}
