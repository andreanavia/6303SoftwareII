using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required, StringLength(100)]
        public string Genre { get; set; } = string.Empty;

        [Range(1, 600)]
        public int Duration { get; set; }  // duración en minutos

        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public string? PosterUrl { get; set; }

        // 🔗 Relación con las funciones o shows de la película
        public ICollection<Show>? Shows { get; set; }
    }
}
