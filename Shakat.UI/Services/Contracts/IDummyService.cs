
using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IDummyService
    {
        Task<IEnumerable<DummyDto>> GetAll();

        Task<DummyDto> GetById(int id);
        Task<DummyDto> Create(DummyDto dummyDto);
        Task<DummyDto> Update(DummyDto dummyDto);
        Task<DummyDto> Delete(int id);
    }
}
 