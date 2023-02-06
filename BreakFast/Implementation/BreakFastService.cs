using BreakFast.DataContext;
using BreakFast.Entity;
using BreakFast.Interface;
using BreakFast.Models;
using BreakFast.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace BreakFast.Implementation
{
    public class BreakFastService : IBreakFastService
    {
        private readonly IBreakfastRepository _breakFastRepository;
        private readonly ApplicationDbContext _dbContext;

        public BreakFastService(ApplicationDbContext dbContext, IBreakfastRepository breakFastRepository)
        {
            _dbContext = dbContext;
            _breakFastRepository = breakFastRepository;
        }

        public async Task<CreateResponse> Create(CreateBreakfastViewModel request)
        {
            try
            {

                var breakFast = new Breakfast()
                {
                    Id = new Guid(),
                    Name = request.Name,
                    EndTime = request.EndTime,
                    StartTime = request.StartTime,
                    Createdby = "Admin",
                    DateCreated = DateTime.Now
                };

                var findBreakFast = _breakFastRepository.GetById(breakFast.Id);

                if (findBreakFast == null)
                {
                    _dbContext.Breakfasts.Add(breakFast);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return new CreateResponse(false,
                                              "",
                                              "No such break fast exist..");
                }

            }
            catch (Exception ex)
            {
                return new CreateResponse(false,
                                             "",
                                             "Something Went wrong..");
            }

            return new CreateResponse(true,
                                              "",
                                              "BreakFast Record successfully created..");

        }

        public async Task<CreateResponse> Delete(Guid id)
        {

            var deleteBreakFast = _breakFastRepository.GetById(id);

            if (deleteBreakFast == null)
            {
                return new CreateResponse(false,
                                             "",
                                              "No such break fast exists");
            }


            try
            {
                _dbContext.Breakfasts.Remove(deleteBreakFast);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new CreateResponse(false,
                                              "",
                                              "Could not delete break fast..");
            }

            return new CreateResponse(true,
                                          "CMS-02",
                                          "The break fast was successfully deleted");
        }

        public async Task<UpdateResponse> Update(Guid id, UpdateBreakFastViewModel request)
        {
            DateTime modified = DateTime.Now;
            try
            {
                var std = _breakFastRepository.GetById(id);

                if (std != null)
                {
                    std.ModifiedDate = modified;
                    std.ModifiedBy = "Admin";
                    std.Name = request.Name;
                    std.StartTime = request.StartTime;
                    std.EndTime = request.EndTime;

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return new UpdateResponse(false,
                                               "",
                                               "No such break fast exist..");
                }
            }
            catch (Exception ex)
            {
                return new UpdateResponse(false,
                                              "",
                                              "No such break fast exist..");
            }
            return new UpdateResponse(false,
                                              "",
                                              "No such break fast exist..");

        }

        public async Task<List<BreakFastViewModel>> LoadAllBreakFast()
        {
            return await _breakFastRepository.GetAllBreakFastDto();

        }

        public async Task<BreakFastViewModel> LoadBreakFastDetail(Guid id)
        {
            return await _breakFastRepository.LoadBreakFastDetailAsync(id);
        }


    }
}
