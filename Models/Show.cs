using System;
using System.Collections.Generic;

namespace MovieReservationSystem.Models
{
    public class Show
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }  // Relación con Movie

        public DateTime StartTime { get; set; }
        public int HallNumber { get; set; }
        public decimal Price { get; set; }

        // Relación con Reservas y Asientos (las crearemos después)
        public ICollection<Seat>? Seats { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
