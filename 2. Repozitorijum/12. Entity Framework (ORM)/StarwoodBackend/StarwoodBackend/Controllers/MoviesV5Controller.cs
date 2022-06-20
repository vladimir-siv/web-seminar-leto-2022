using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StarwoodBackend.Models;

namespace StarwoodBackend.Controllers
{
	[Route("api/movies-v5")]
	[ApiController]
	public class MoviesV5Controller : ControllerBase
	{
		private static readonly Random RNG = new Random();
		private static readonly AppDbContext db = new AppDbContext();

		[HttpGet("most-popular")]
		public Movie MostPopular()
		{
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

			return movie;
		}

		[HttpGet("trending")]
		public List<Movie> Trending(int? count = 4)
		{
			var Movies = db.Movies.Include("Genres").ToArray();

			var trending = new List<Movie>((int)count);

			for (var i = 0; i < count; ++i)
			{
				var movieIndex = RNG.Next(Movies.Length);
				trending.Add(Movies[movieIndex]);
			}

			return trending;
		}

		[HttpGet("thrillers")]
		public List<Movie> Thrillers()
		{
			var query =
				from movie in db.Movies.Include("Genres")
				where movie.Genres.Any(genre => genre.Name == "Thriller")
				select movie;

			return query.ToList();
		}
	}
}
