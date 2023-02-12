using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IMaterialTypeInfoService
    {
        Task<IEnumerable<MaterialTypeInfoDto>> GetAll();
    }
}
