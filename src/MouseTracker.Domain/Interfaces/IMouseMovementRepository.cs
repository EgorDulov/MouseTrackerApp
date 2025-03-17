using MouseTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MouseTracker.Domain.Interfaces
{
    public interface IMouseMovementRepository
    {
        Task SaveMouseMovementsAsync(IEnumerable<MouseMovement> movements);
    }
}