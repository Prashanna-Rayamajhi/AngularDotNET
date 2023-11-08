namespace MoviesAPI.ModelDTOs
{
    public class FilterMoviesDTO
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PaginationDTO PaginationDTO 
        {
            get
            {
                return new PaginationDTO() { Page = Page, PageSize = PageSize };
            }
        }
        public string Title { get; set; }

        public int GenreID { get; set; }

        public bool InTheaters { get; set; }

        public bool UpComingReleases { get; set; }
    }
}
