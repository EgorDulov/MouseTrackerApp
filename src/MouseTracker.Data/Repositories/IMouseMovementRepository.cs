using MouseTracker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MouseTracker.Data.Repositories
{
    public interface IMouseMovementRepository
    {
        Task SaveMouseMovementsAsync(IEnumerable<MouseMovement> movements);
    }
}