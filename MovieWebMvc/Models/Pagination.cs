namespace MovieWebMvc.Models
{
    public class Pagination
    {
        public int TotalMovie { get; set; }
        public int PageSize { get; set; } = 5;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalMovie/PageSize);

    }
}
