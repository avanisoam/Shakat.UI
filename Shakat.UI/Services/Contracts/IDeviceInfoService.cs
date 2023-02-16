using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IDeviceInfoService
    {
        Task<IEnumerable<DeviceInfoDto>> GetAll();
        Task<DeviceInfoDto> GetById(int id);

        //Task<IEnumerable<MaterialTypeInfoDto>> GetByMaterialTypeId(int id);
        Task<DeviceInfoDto> Create(DeviceInfoDto deviceInfoDto);

        Task<DeviceInfoDto> Update(DeviceInfoDto deviceInfoDto);

        Task<DeviceInfoDto> Delete(int id);
    }
}
