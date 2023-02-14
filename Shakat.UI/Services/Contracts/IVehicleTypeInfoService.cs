using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IVehicleTypeInfoService
    {
        Task<IEnumerable<VehicleTypeInfoDto>> GetAll();
        Task<VehicleTypeInfoDto> GetById(int id);
        Task<VehicleTypeInfoDto> Create(VehicleTypeInfoDto vehicleTypeDto);

        Task<VehicleTypeInfoDto> Update(VehicleTypeInfoDto vehicleTypeDto);

        Task<VehicleTypeInfoDto> Delete(int id);
    }
}
