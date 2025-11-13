namespace MovieReservationSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ShowId { get; set; }
        public Show? Show { get; set; }
        public decimal Total { get; set; }

        public ICollection<ReservationSeat>? ReservationSeats { get; set; }
    }
}
