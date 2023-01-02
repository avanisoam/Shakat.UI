using Shakat.Shared.Models.RequestModels;
using Shakat.Shared.Models.ResponseModels;

namespace Shakat.UI.Services.Contracts
{
    public interface ILogisticsOrderService
    {
        Task<IEnumerable<LogisticsOrderResponseDto>> GetAllLogisticsOrders();
        Task<LogisticsOrderRequestDto> CreateLogisticOrder(LogisticsOrderRequestDto logisticsOrderRequestDto);
    }
}
