using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IDeviceHistoryService
    {
        Task<IEnumerable<DeviceHistoryDto>> GetAll();
        Task<DeviceHistoryDto> GetById(int id);
        Task<DeviceHistoryDto> Create(DeviceHistoryDto deviceHistoryDto);

        Task<DeviceHistoryDto> Update(DeviceHistoryDto deviceHistoryDto);

        Task<DeviceHistoryDto> Delete(int id);
    }
}
