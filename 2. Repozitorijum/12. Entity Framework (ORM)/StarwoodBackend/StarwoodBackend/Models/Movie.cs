namespace StarwoodBackend.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
