using System.Data.Entity;

using StarwoodBackend.Models;

namespace StarwoodBackend
{
	public class AppDbContext : DbContext
	{
		public static readonly AppDbContext Default = new AppDbContext();

		public DbSet<User> Users { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }

		public AppDbContext() : base(@"Data Source=DESKTOP-7G1TKFC;Initial Catalog=StarwoodDB;User ID=sa;Password=A1 b2 C3;")
		{
			if (!Database.Exists())
			{
				InsertInitialMockData();
			}
		}

		~AppDbContext()
		{
			Dispose();
		}

		private void InsertInitialMockData()
		{
			var theFastAndFuriousMovie = new Movie
			{
				Id = 1,
				Name = "The Fast & Furious",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Action",
						Ratio = 0.43,
					},
					new Genre
					{
						Name = "Adventure",
						Ratio = 0.23,
					},
					new Genre
					{
						Name = "Crime",
						Ratio = 0.34,
					},
				}
			};
			var avatarMovie = new Movie
			{
				Id = 2,
				Name = "Avatar",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Action",
						Ratio = 0.21,
					},
					new Genre
					{
						Name = "Adventure",
						Ratio = 0.24,
					},
					new Genre
					{
						Name = "Fantasy",
						Ratio = 0.55,
					},
				}
			};
			var theHangoverMovie = new Movie
			{
				Id = 3,
				Name = "The Hangover",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Comedy",
						Ratio = 1,
					},
				}
			};
			var starWarsMovie = new Movie
			{
				Id = 4,
				Name = "Star Wars: A New Hope",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Action",
						Ratio = 0.26,
					},
					new Genre
					{
						Name = "Adventure",
						Ratio = 0.14,
					},
					new Genre
					{
						Name = "Fantasy",
						Ratio = 0.6,
					},
				}
			};
			var theLordOfTheRingsMovie = new Movie
			{
				Id = 5,
				Name = "The Lord of the Rings: The Two Towers",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Action",
						Ratio = 0.24,
					},
					new Genre
					{
						Name = "Adventure",
						Ratio = 0.73,
					},
					new Genre
					{
						Name = "Drama",
						Ratio = 0.03,
					},
				}
			};
			var forrestGumpMovie = new Movie
			{
				Id = 6,
				Name = "Forrest Gump",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Drama",
						Ratio = 0.65,
					},
					new Genre
					{
						Name = "Romance",
						Ratio = 0.35,
					},
				}
			};
			var theTerminatorMovie = new Movie
			{
				Id = 7,
				Name = "The Terminator",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Action",
						Ratio = 0.62,
					},
					new Genre
					{
						Name = "Sci-Fi",
						Ratio = 0.38,
					},
				}
			};
			var theMatrixMovie = new Movie
			{
				Id = 8,
				Name = "The Matrix",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Action",
						Ratio = 0.46,
					},
					new Genre
					{
						Name = "Sci-Fi",
						Ratio = 0.54,
					},
				}
			};
			var shutterIslandMovie = new Movie
			{
				Id = 9,
				Name = "Shutter Island",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Mystery",
						Ratio = 0.89,
					},
					new Genre
					{
						Name = "Thriller",
						Ratio = 0.11,
					},
				}
			};
			var jokerMovie = new Movie
			{
				Id = 10,
				Name = "Joker",
				Genres = new List<Genre>
				{
					new Genre
					{
						Name = "Crime",
						Ratio = 0.47,
					},
					new Genre
					{
						Name = "Drama",
						Ratio = 0.39,
					},
					new Genre
					{
						Name = "Thriller",
						Ratio = 0.14,
					},
				}
			};

			Movies.Add(theFastAndFuriousMovie);
			Movies.Add(avatarMovie);
			Movies.Add(theHangoverMovie);
			Movies.Add(starWarsMovie);
			Movies.Add(theLordOfTheRingsMovie);
			Movies.Add(forrestGumpMovie);
			Movies.Add(theTerminatorMovie);
			Movies.Add(theMatrixMovie);
			Movies.Add(shutterIslandMovie);
			Movies.Add(jokerMovie);

			SaveChanges();
		}
	}
}
