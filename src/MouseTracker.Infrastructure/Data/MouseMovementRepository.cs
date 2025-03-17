using MouseTracker.Domain.Entities;
using MouseTracker.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MouseTracker.Infrastructure.Data
{
    public class MouseMovementRepository : IMouseMovementRepository
    {
        private readonly DataContext _context;

        public MouseMovementRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveMouseMovementsAsync(IEnumerable<MouseMovement> movements)
        {
            await _context.MouseMovements.AddRangeAsync(movements);
            await _context.SaveChangesAsync();
        }
    }
}