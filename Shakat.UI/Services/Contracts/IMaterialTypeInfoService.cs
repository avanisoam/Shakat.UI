using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IMaterialTypeInfoService
    {
        Task<IEnumerable<MaterialTypeInfoDto>> GetAll();
        Task<MaterialTypeInfoDto> GetById(int id);

        //Task<IEnumerable<MaterialTypeInfoDto>> GetByMaterialTypeId(int id);
        Task<MaterialTypeInfoDto> Create(MaterialTypeInfoDto materialTypeInfoDto);

        Task<MaterialTypeInfoDto> Update(MaterialTypeInfoDto materialTypeInfoDto);

        Task<MaterialTypeInfoDto> Delete(int id);
    }
}
