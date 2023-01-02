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

        public IEnumerable<LogisticsOrderResponseDto> LogisticsOrders { get; set; } = new List<LogisticsOrderResponseDto>();

        protected override async Task OnInitializedAsync()
        {
            LogisticsOrders = await LogisticsOrderService.GetAllLogisticsOrders();
        }
    }
}
