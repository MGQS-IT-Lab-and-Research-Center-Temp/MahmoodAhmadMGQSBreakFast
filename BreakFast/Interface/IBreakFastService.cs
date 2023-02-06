using BreakFast.Models.Response;
using BreakFast.Models;

namespace BreakFast.Interface
{
    public interface IBreakFastService
    {
        Task<CreateResponse> Create(CreateBreakfastViewModel request);
        Task<List<BreakFastViewModel>> LoadAllBreakFast();
        Task<BreakFastViewModel> LoadBreakFastDetail(Guid id);
        Task<UpdateResponse> Update(Guid id, UpdateBreakFastViewModel updateStudentDto);
        Task<CreateResponse> Delete(Guid id);
    } 
}
