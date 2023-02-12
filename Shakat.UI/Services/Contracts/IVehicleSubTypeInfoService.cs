using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IVehicleSubTypeInfoService
    {
        Task<IEnumerable<VehicleSubTypeInfoDto>> GetAll();
        Task<VehicleSubTypeInfoDto> GetById(int id);

		Task<IEnumerable<VehicleSubTypeInfoDto>> GetByVehicleTypeId(int id);
		Task<VehicleSubTypeInfoDto> Create(VehicleSubTypeInfoDto vehicleSubTypeInfoDto);

        Task<VehicleSubTypeInfoDto> UpdateSubType(VehicleSubTypeInfoDto vehicleSubTypeInfoDto);

        Task<VehicleSubTypeInfoDto> Delete(int id);
    }
}
