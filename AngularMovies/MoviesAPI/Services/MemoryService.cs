using MoviesAPI.Models;
using MoviesAPI.Services.Interface;

namespace MoviesAPI.Services
{
    public class MemoryService : IMemoryService
    {
        private List<Genre> _genres = new List<Genre>();
        public MemoryService()
        {
            this._genres = new List<Genre>(){
             new Genre
             {
                 ID = 1,
                 Name = "Action"
             },
             new Genre
             {
                 ID = 2,
                 Name = "Drama"
             },
             new Genre
             {
                 ID= 3,
                 Name = "Comedy"
             },
             new Genre
             {
                  ID= 4,
                  Name = "Adventure"
             },
             new Genre
             {
                 ID= 5,
                 Name = "Sci-Fi"
             },
             new Genre
             {
                 ID= 6,
                 Name="Horror"
             },
             new Genre
             {
                 ID= 7,
                 Name="Vampire"
             },
             new Genre
             {
                 ID= 8,
                 Name = "Anime"
             },
             new Genre
             {
                 ID = 9,
                 Name = "Romance"
             },
             new Genre
             {
                 ID = 10,
                 Name = "Thriller"
             }

         };

        }
        public async Task<List<Genre>> GetAllGenres()
        {
            Task.Delay(1000);
            return this._genres;
        }


        public async Task<Genre> GetGenreById(int id)
        {
            Task.Delay(1000);
            var foundResult = _genres.FirstOrDefault(genre => genre.ID == id);
            return foundResult;
        }
    }
}
