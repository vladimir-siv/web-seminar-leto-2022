using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarwoodBackend.Controllers
{
    [Route("api/movies-v2")]
    [ApiController]
    public class MoviesV2Controller : ControllerBase
    {
        private static readonly Random RNG = new Random();

        [HttpGet("most-popular")]
        public string MostPopular()
        {
            return "The Shawshank Redemption";
        }

        [HttpGet("trending")]
        public List<string> Trending(int? count = 4)
        {
            var Movies = System.IO.File.ReadAllLines(@"Resources\movies.txt");

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
