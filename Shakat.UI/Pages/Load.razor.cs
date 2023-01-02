using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.Shared.Models.RequestModels;
using Shakat.Shared.Models.ResponseModels;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages
{
    public partial class Load
    {
        [Inject]
        public ILogisticsOrderService LogisticsOrderService { get; set; }

        public LogisticsOrderRequestDto newLogisticsOrderObject { get; set; } = new();

        public IEnumerable<LogisticsOrderRequestDto> LogisticsOrders { get; set; } = new List<LogisticsOrderRequestDto>();

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public string Value { get; set; }

        public EventCallback<string> ValueChanged { get; set; }


        protected override async Task OnInitializedAsync()
        {
            newLogisticsOrderObject.CustomerId = 1;
            newLogisticsOrderObject.VehicleSubTypeId = 1;
            newLogisticsOrderObject.ProductId = 5;

             //LogisticsOrders = await LogisticsOrderService.GetAllLogisticsOrders();

            //NewOrder = new Order
            //{
            //    Id = 1,
            //    Source = "Rishikesh",
            //    Destination = "Gurgaon",
            //    Type = "FullLoad",
            //    Weight = 100,
            //    MaterialTypeId = 1,
            //    Date = new DateTime(1984, 01, 30),
            //    VehicleSubTypeId = 1,
            //    VehicleTypeId = 1

            //};
        }

        public async Task AddItem()
        {
            await LogisticsOrderService.CreateLogisticOrder(newLogisticsOrderObject);

            newLogisticsOrderObject = new();

            //LogisticsOrders = await LogisticsOrderService.GetAllLogisticsOrders();

            MyNavigationManager.NavigateTo("/fullload");
        }

        public Task OnValueChanged(ChangeEventArgs e)
        {
            Value = e.Value.ToString();

            newLogisticsOrderObject.MaterialTypeId = Convert.ToInt32(Value);
            

            return ValueChanged.InvokeAsync(Value);
        }

        //public Task OnRadioChanged(ChangeEventArgs e)
        //{
        //    Value = e.Value.ToString();

        //    newLogisticsOrderObject.VehicleSubTypeId = Convert.ToInt32(Value);


        //    return ValueChanged.InvokeAsync(Value);
        //}
    }
}
