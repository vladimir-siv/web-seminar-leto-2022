using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarwoodBackend.Controllers
{
	[Route("api/movies")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private static readonly Random RNG = new Random();
		private static readonly string[] Movies = new string[]
		{
			"The Fast & Furious",
			"Avatar",
			"The Hangover",
			"Star Wars: A New Hope",
			"The Lord of the Rings: The Two Towers",
			"Forrest Gump",
			"The Terminator",
			"The Matrix",
			"Shutter Island",
			"Joker"
		};

		[HttpGet("most-popular")]
		public string MostPopular()
		{
			return "The Shawshank Redemption";
		}

		[HttpGet("trending")]
		public List<string> Trending(int? count = 4)
		{
			var trending = new List<string>((int)count);

			for (var i = 0; i < count; ++i)
			{
				var movieIndex = RNG.Next(Movies.Length);
				trending.Add(Movies[movieIndex]);
			}

			return trending;
		}
	}
}
