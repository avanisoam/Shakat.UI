using Shakat.Shared.Models.RequestModels;
using Shakat.Shared.Models.ResponseModels;

namespace Shakat.UI.Services.Contracts
{
    public interface ILogisticsOrderService
    {
        Task<IEnumerable<LogisticsOrderRequestDto>> GetAllLogisticsOrders();
        Task<LogisticsOrderRequestDto> CreateLogisticOrder(LogisticsOrderRequestDto logisticsOrderRequestDto);
    }
}
