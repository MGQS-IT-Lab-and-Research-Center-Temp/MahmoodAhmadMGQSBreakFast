using BreakFast.Interface;
using BreakFast.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreakFast.Controllers
{
    public class BreakFastController : Controller
    {
        private readonly IBreakFastService _breakFastService;

        public BreakFastController(IBreakFastService breakFastService)
        {
            _breakFastService = breakFastService;
        }

        #region Crud Student

        [HttpGet("breakfast/create")]
        public IActionResult CreateBreakFast() =>
            View();

        [HttpPost("breakfast/create")] 
        public async Task<IActionResult> CreateBreakFast([FromForm] CreateBreakfastViewModel createBreakfast)
        {
            try
            {
                var response = await _breakFastService.Create(createBreakfast);
                return RedirectToAction("ViewBreakFast", "BreakFast");
            }
            catch
            {
                return Ok(new
                {
                    status = "error",
                    message = "Something happened. Please try again later."
                });
            }

        }

        [HttpGet("breakfast")]
        public async Task<IActionResult> ViewBreakFast()
        {
            var instances =
            await _breakFastService.LoadAllBreakFast();
            return View(instances);
        }

        [HttpGet("breakfast/data")]
        public async Task<IActionResult> LoadBreakFastAsync()
        {
            var instances =
                await _breakFastService.LoadAllBreakFast();
            return View(instances);
        }

        [HttpGet("breakfast/{id}")] 
        public async Task<IActionResult> ViewBreakFastDetail([FromRoute] Guid id)
        {
            var instance = await _breakFastService.LoadBreakFastDetail(id);

            return instance == null
                       ? (IActionResult)NotFound()
                       : View(instance);
        }

        [HttpGet("breakfast/{id}/edit")]
        public async Task<IActionResult> EditBreakFastAsync(Guid id)
        {
            var instance = await _breakFastService.LoadBreakFastDetail(id);

            if (instance == null)
            {
                return NotFound();
            }

            return View(instance);
        }

        [HttpPost("breakfast/{id}/edit")]
        public async Task<IActionResult> EditBreakFast([FromRoute] Guid id, [FromForm] UpdateBreakFastViewModel update
            )
        {
            try
            {
                var response = await _breakFastService.Update(id, update);
                return RedirectToAction("ViewBreakFast", "BreakFast");
            }
            catch
            {
                return Ok(new
                {
                    status = "error",
                    message = "Something happened. Please try again later."
                });
            }
        }

        [HttpPost("breaskFast/{id}/delete")]
        public async Task<IActionResult> DeleteBreakfast(Guid id)
        {
            try
            {
                var response = await _breakFastService.Delete(id);
                return RedirectToAction("ViewStudent", "Student");
            }
            catch
            {
                return Ok(new
                {
                    status = "error",
                    message = "Something happened. Please try again later."
                });
            }
        }

        #endregion
    }
}
