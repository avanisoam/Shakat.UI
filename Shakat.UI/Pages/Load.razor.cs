using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages
{
    public partial class Load
    {
        [Inject]
        public IHelloWorldService HelloWorldService { get; set; }

        public Order NewOrder { get; set; }

        public string? Value { get; set; }

        protected override async Task OnInitializedAsync()
        {
            NewOrder = new Order
            {
                Id = 1,
                Source = "Rishikesh",
                Destination = "Gurgaon",
                Type = "FullLoad",
                Weight = 100,
                MaterialTypeId = 1,
                Date = new DateTime(1984, 01, 30),
                VehicleSubTypeId = 1,
                VehicleTypeId = 1

            };
        }
    }

    public class Order
    {
        public int? Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public double Weight { get; set; }
        public int MaterialTypeId { get; set; }
        public DateTime Date { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleSubTypeId { get; set; }
        public string Type { get; set; }
    }
}
