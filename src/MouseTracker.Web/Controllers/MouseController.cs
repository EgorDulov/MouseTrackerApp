using Microsoft.AspNetCore.Mvc;
using MouseTracker.Data.Repositories;
using MouseTracker.Data.Models;
using MouseTracker.Web.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MouseTracker.Web.Controllers
{
    public class MouseController : Controller
    {
        private readonly IMouseMovementRepository _repository;

        public MouseController(IMouseMovementRepository repository)
        {
            _repository = repository;
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
                var movements = positions.Select(p => new MouseMovement
                {
                    XCoordinate = p.X,
                    YCoordinate = p.Y,
                    Timestamp = p.T
                }).ToList();

                await _repository.SaveMouseMovementsAsync(movements);
                return Ok(new SuccessResponse { Message = "Данные успешно сохранены" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ошибка при сохранении данных", error = ex.Message });
            }
        }
    }
}