
using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IRouteInfoService
    {
        Task<IEnumerable<RouteInfoDto>> GetAll();

        Task<RouteInfoDto> GetById(int id);
        Task<RouteInfoDto> Create(RouteInfoDto routeInfoDto);
        Task<RouteInfoDto> Update(RouteInfoDto routeInfoDto);
        Task<RouteInfoDto> Delete(int id);
    }
}
 