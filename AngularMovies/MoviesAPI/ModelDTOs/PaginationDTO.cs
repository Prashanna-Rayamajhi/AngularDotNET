namespace MoviesAPI.ModelDTOs
{
    public class PaginationDTO
    {
        public int  Page { get; set; } = 1;
        private int pageSize = 5;
        private readonly int maxRecords = 25;

        public int PageSize { 
            get
            {
                return this.pageSize;
            }
            set
            {
                 this.pageSize = value > maxRecords? maxRecords: value;
            } 
        }
    }
}
