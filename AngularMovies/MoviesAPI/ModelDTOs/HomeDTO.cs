namespace MoviesAPI.ModelDTOs
{
    public class HomeDTO
    {
        public List<MovieDTO> InTheaters { get; set; }
        public List<MovieDTO> FutureReleases { get; set; } 
        
        public List<MovieDTO> Movies { get; set; }
    }
}
