using Blazored.Modal;
using Blazored.Modal.Services;
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

		[Inject]
		public IMaterialTypeInfoService MaterialTypeInfoService { get; set; }

        public LogisticsOrderRequestDto newLogisticsOrderObject { get; set; } = new();

        public IEnumerable<LogisticsOrderResponseDto> LogisticsOrders { get; set; } = new List<LogisticsOrderResponseDto>();

        public IEnumerable<MaterialTypeInfoDto> MaterialTypeInfos { get; set; } = new List<MaterialTypeInfoDto>();

        public MaterialTypeInfoDto materialTypeInfoDtoObject { get; set; } = new();

        [Inject]
        NavigationManager MyNavigationManager { get; set; }

        public string Value { get; set; }

        public int MaterialTypeInfoId { get; set; }

        public int VehicleSubTypeInfoId { get; set; }

		public EventCallback<string> ValueChanged { get; set; }

		public ModalParameters Parameters = new ModalParameters();

		[CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;


		protected override async Task OnInitializedAsync()
        {
            
            newLogisticsOrderObject.CustomerId = 1;
            //newLogisticsOrderObject.VehicleSubTypeId = 1;
            newLogisticsOrderObject.ProductId = 5;

            LogisticsOrders = await LogisticsOrderService.GetAllLogisticsOrders();
            MaterialTypeInfos = await MaterialTypeInfoService.GetAll();
			//Parameters.Add("LogisticsOrder", LogisticsOrders);




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
            newLogisticsOrderObject.VehicleSubTypeId = VehicleSubTypeInfoId ;

			newLogisticsOrderObject.MaterialTypeId = MaterialTypeInfoId;
            await LogisticsOrderService.CreateLogisticOrder(newLogisticsOrderObject);

            newLogisticsOrderObject = new();

            LogisticsOrders = await LogisticsOrderService.GetAllLogisticsOrders();

            MyNavigationManager.NavigateTo("/fullload");
        }

        public Task OnValueChanged(ChangeEventArgs e)
        {
            Value = e.Value.ToString();

            newLogisticsOrderObject.MaterialTypeId = Convert.ToInt32(Value);
            

            return ValueChanged.InvokeAsync(Value);
        }

		void ClickHandler(int vehicleSubTypeId)
		{
			VehicleSubTypeInfoId = vehicleSubTypeId;
		}
	}
}
