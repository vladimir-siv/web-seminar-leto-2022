using System.ComponentModel.DataAnnotations;

namespace StarwoodBackend.Models
{
	public class Movie
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Genre> Genres { get; set; }
	}
}
