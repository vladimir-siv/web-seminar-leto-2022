using System.Xml;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarwoodBackend.Controllers
{
    [Route("api/movies-v3")]
    [ApiController]
    public class MoviesV3Controller : ControllerBase
    {
        private static readonly Random RNG = new Random();

        private static string[] ReadXMLMovies(string file)
        {
            XmlDocument document = new XmlDocument();
            document.Load(file);

            XmlElement root = document.DocumentElement;

            string[] movies = new string[root.ChildNodes.Count];

            for (var i = 0; i < root.ChildNodes.Count; ++i)
            {
                var child = root.ChildNodes[i];
                movies[i] = child.Attributes["name"].Value;
            }

            return movies;
        }

        [HttpGet("most-popular")]
        public string MostPopular()
        {
            return "The Shawshank Redemption";
        }

        [HttpGet("trending")]
        public List<string> Trending(int? count = 4)
        {
            var Movies = ReadXMLMovies(@"Resources\movies.xml");

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
