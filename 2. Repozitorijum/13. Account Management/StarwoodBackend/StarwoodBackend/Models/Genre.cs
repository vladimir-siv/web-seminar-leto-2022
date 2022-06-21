using System.ComponentModel.DataAnnotations;

namespace StarwoodBackend.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public double Ratio { get; set; }
	}
}
