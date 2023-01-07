
using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IShipmentService
    {
        Task<IEnumerable<ShipmentDto>> GetAll();

        Task<ShipmentDto> GetById(int id);
        Task<ShipmentDto> Create(ShipmentDto shipmentDto);
        Task<ShipmentDto> Update(ShipmentDto shipmentDto);
        Task<ShipmentDto> Delete(int id);
    }
}
 