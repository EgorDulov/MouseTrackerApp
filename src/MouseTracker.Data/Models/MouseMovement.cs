namespace MouseTracker.Data.Models
{
    public class MouseMovement
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}