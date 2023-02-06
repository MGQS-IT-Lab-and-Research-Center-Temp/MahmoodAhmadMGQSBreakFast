using BreakFast.DataContext;
using BreakFast.Entity;
using BreakFast.Interface;
using BreakFast.Models;
using Microsoft.EntityFrameworkCore;

namespace BreakFast.Implementation
{
    public class BreakFastRepository : IBreakfastRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BreakFastRepository(ApplicationDbContext dbContex)
        {
            _dbContext = dbContex;
        }
        public List<Breakfast> GetAllBreakFast()
        {
            return _dbContext.Breakfasts.ToList();
        }

        public async Task<BreakFastViewModel?> LoadBreakFastDetailAsync(Guid id) =>
          await _dbContext.Breakfasts
                          .Where(x => x.Id == id)
                          .Select(x => new BreakFastViewModel
                          {
                              Id = x.Id,
                              Name = x.Name,
                              StartTime = x.StartTime,
                              EndTime = x.EndTime,
                              Createdby = x.Createdby,
                              ModifiedBy = x.ModifiedBy,
                              DateCreated = x.DateCreated,
                              ModifiedDate = x.ModifiedDate
                          })
                          .FirstOrDefaultAsync();

        public async Task<List<BreakFastViewModel>> GetAllBreakFastDto()
        {
            return await _dbContext.Breakfasts.Select(x => new BreakFastViewModel
            {
                Name = x.Name,
                StartTime = x.StartTime,
                EndTime = x.EndTime
            }).ToListAsync();
        }

        public Breakfast GetById(Guid id)
        {
            return _dbContext.Breakfasts.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
