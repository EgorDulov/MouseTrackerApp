using MouseTracker.Domain.Entities;
using MouseTracker.Domain.Interfaces;
using MouseTracker.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseTracker.Application.UseCases
{
    public class SaveMouseMovementsUseCase
    {
        private readonly IMouseMovementRepository _repository;

        public SaveMouseMovementsUseCase(IMouseMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(IEnumerable<MousePositionDTO> positions)
        {
            var movements = positions.Select(p => new MouseMovement
            {
                XCoordinate = p.X,
                YCoordinate = p.Y,
                Timestamp = p.T
            }).ToList();

            await _repository.SaveMouseMovementsAsync(movements);
        }
    }
}