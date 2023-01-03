using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleTypeDto>> GetAll();
        Task<VehicleTypeDto> GetById(int id);
        Task<VehicleTypeDto> Create(VehicleTypeDto vehicleTypeDto);

        Task<VehicleTypeDto> UpdateSubType(VehicleTypeDto vehicleTypeDto);

        Task<VehicleTypeDto> Delete(int id);
    }
}
