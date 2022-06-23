using Microsoft.AspNetCore.Mvc;

namespace Starwood.Controllers
{
	public class MoviesController : Controller
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

		public IActionResult Trending(int? count = 4)
		{
			var trending = new List<string>((int)count);

			for (var i = 0; i < count; ++i)
			{
				var movieIndex = RNG.Next(Movies.Length);
				trending.Add(Movies[movieIndex]);
			}

			ViewBag.TrendingMovies = trending;

			return View();
		}
	}
}
