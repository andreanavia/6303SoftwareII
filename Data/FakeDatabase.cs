using MovieReservationSystem.Models;

namespace MovieReservationSystem.Data
{
    public static class FakeDatabase
    {
        public static List<Movie> Movies { get; } = new List<Movie>()
        {
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Duration = 148, ReleaseDate = new DateTime(2010, 7, 16) },
            new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", Duration = 152, ReleaseDate = new DateTime(2008, 7, 18) }
        };
    }
}
