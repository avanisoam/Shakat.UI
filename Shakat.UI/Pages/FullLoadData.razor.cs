using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models.RequestModels;
using Shakat.Shared.Models.ResponseModels;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages
{
    public partial class FullLoadData
    {
        [Inject]
        public ILogisticsOrderService LogisticsOrderService { get; set; }

        public IEnumerable<LogisticsOrderRequestDto> LogisticsOrders { get; set; } = new List<LogisticsOrderRequestDto>();

        protected override async Task OnInitializedAsync()
        {
            LogisticsOrders = await LogisticsOrderService.GetAllLogisticsOrders();
        }
    }
}
