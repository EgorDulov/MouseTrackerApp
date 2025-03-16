using MouseTracker.Data.Models;

namespace MouseTracker.Data.Repositories
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