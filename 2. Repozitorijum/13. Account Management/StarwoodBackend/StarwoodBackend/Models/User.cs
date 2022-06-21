using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarwoodBackend.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[StringLength(100)]
		[Index(IsUnique = true)]
		public string Username { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
