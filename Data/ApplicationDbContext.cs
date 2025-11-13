using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tablas personalizadas
        public DbSet<Movie> Movies { get; set; }    
        public DbSet<Show> Shows { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        // Usuarios personalizados (si tienes tu propio modelo User.cs)
        public DbSet<User> Users { get; set; }
    }
}
