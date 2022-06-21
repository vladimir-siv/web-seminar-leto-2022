using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StarwoodBackend.Models;

namespace StarwoodBackend.Controllers
{
	[Route("api/movies-v6")]
	[ApiController]
	public class MoviesV6Controller : ControllerBase
	{
		private static readonly Random RNG = new Random();

		[HttpGet("most-popular")]
		public IActionResult MostPopular()
		{
			if (!AccountController.AuthenticateClaims(Request)) return Unauthorized();

			Movie movie = new Movie
			{
				Id = 0,
				Name = "The Shawshank Redemption",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Drama",
						Ratio = 0.94
					},
					new Genre
					{
						Name = "Crime",
						Ratio = 0.06
					}
				}
			};

			return Ok(movie);
		}

		[HttpGet("trending")]
		public IActionResult Trending(int? count = 4)
		{
			if (!AccountController.AuthenticateClaims(Request)) return Unauthorized();

			var db = AppDbContext.Default;

			var Movies = db.Movies.Include("Genres").ToArray();

			var trending = new List<Movie>((int)count);

			for (var i = 0; i < count; ++i)
			{
				var movieIndex = RNG.Next(Movies.Length);
				trending.Add(Movies[movieIndex]);
			}

			return Ok(trending);
		}

		[HttpGet("thrillers")]
		public IActionResult Thrillers()
		{
			if (!AccountController.AuthenticateClaims(Request)) return Unauthorized();

			var db = AppDbContext.Default;

			var query =
				from movie in db.Movies.Include("Genres")
				where movie.Genres.Any(genre => genre.Name == "Thriller")
				select movie;

			return Ok(query.ToList());
		}
	}
}
