namespace MovieReservationSystem.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Show? Show { get; set; }

        public string Row { get; set; } = null!;
        public int Number { get; set; }
    }
}
