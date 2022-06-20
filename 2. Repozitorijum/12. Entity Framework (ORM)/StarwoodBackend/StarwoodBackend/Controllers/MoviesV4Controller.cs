using System.Xml;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StarwoodBackend.Models;

namespace StarwoodBackend.Controllers
{
	[Route("api/movies-v4")]
	[ApiController]
	public class MoviesV4Controller : ControllerBase
	{
		private static readonly Random RNG = new Random();

		private static Movie[] ReadXMLMovies(string file)
		{
			XmlDocument document = new XmlDocument();
			document.Load(file);

			XmlElement root = document.DocumentElement;

			Movie[] movies = new Movie[root.ChildNodes.Count];

			for (var i = 0; i < root.ChildNodes.Count; ++i)
			{
				XmlNode movieElement = root.ChildNodes[i];

				Movie movie = new Movie();
				movie.Id = int.Parse(movieElement.Attributes["id"].Value);

				XmlNode nameElement = movieElement.ChildNodes[0];
				movie.Name = nameElement.ChildNodes[0].Value;

				movie.Genres = new List<Genre>();

				XmlNode genresElement = movieElement.ChildNodes[1];
				for (var j = 0; j < genresElement.ChildNodes.Count; ++j)
				{
					XmlNode genreElement = genresElement.ChildNodes[j];

					Genre genre = new Genre();
					genre.Name = genreElement.Attributes["name"].Value;
					genre.Ratio = double.Parse(genreElement.Attributes["ratio"].Value);

					movie.Genres.Add(genre);
				}

				movies[i] = movie;
			}

			return movies;
		}

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
			var Movies = ReadXMLMovies(@"Resources\movies-extended.xml");

			var trending = new List<Movie>((int)count);

			for (var i = 0; i < count; ++i)
			{
				var movieIndex = RNG.Next(Movies.Length);
				trending.Add(Movies[movieIndex]);
			}

			return trending;
		}
	}
}
