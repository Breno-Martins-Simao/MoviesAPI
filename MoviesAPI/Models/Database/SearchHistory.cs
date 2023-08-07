namespace MoviesAPI.Models.Database
{
#nullable disable
    public class SearchHistory
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public virtual Movie MovieResulted { get; set; }
    }
}
