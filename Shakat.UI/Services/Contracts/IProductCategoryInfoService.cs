using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IProductCategoryInfoService
    {
        Task<IEnumerable<ProductCategoryInfoDto>> GetAll();
        Task<ProductCategoryInfoDto> GetById(int id);

        Task<ProductCategoryInfoDto> Create(ProductCategoryInfoDto productCategoryInfoDto);

        Task<ProductCategoryInfoDto> Update(ProductCategoryInfoDto productCategoryInfoDto);

        Task<ProductCategoryInfoDto> Delete(int id);
    }
}
