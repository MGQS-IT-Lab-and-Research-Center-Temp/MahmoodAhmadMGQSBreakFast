using BreakFast.Entity;
using BreakFast.Models;

namespace BreakFast.Interface
{
    public interface IBreakfastRepository
    {
        List<Breakfast> GetAllBreakFast();
        Breakfast GetById(Guid id);
        Task<List<BreakFastViewModel>> GetAllBreakFastDto();
        Task<BreakFastViewModel?> LoadBreakFastDetailAsync(Guid id);
    }
}
