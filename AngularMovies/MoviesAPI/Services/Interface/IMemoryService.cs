using MoviesAPI.Models;

namespace MoviesAPI.Services.Interface
{
    public interface IMemoryService
    {
         Task<List<Genre>> GetAllGenres();

        Task <Genre> GetGenreById(int id);
    }
}
