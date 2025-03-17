using Microsoft.AspNetCore.Mvc;
using MouseTracker.Application.UseCases;
using MouseTracker.Application.DTOs;
using System.Threading.Tasks;

namespace MouseTracker.Web.Controllers
{
    public class MouseController : Controller
    {
        private readonly SaveMouseMovementsUseCase _saveUseCase;

        public MouseController(SaveMouseMovementsUseCase saveUseCase)
        {
            _saveUseCase = saveUseCase;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMousePositions([FromBody] List<MousePositionDTO> positions)
        {
            try
            {
                await _saveUseCase.ExecuteAsync(positions);
                return Ok(new SuccessResponse { Message = "Данные успешно сохранены" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ошибка при сохранении данных", error = ex.Message });
            }
        }
    }
}