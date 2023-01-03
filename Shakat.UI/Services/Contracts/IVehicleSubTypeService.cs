using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IVehicleSubTypeService
    {
        Task<IEnumerable<VehicleSubTypeDto>> GetAll();
        Task<VehicleSubTypeDto> GetById(int id);
        Task<VehicleSubTypeDto> Create(VehicleSubTypeDto vehicleSubTypeDto);

        Task<VehicleSubTypeDto> UpdateSubType(VehicleSubTypeDto vehicleSubTypeDto);

        Task<VehicleSubTypeDto> Delete(int id);
    }
}
