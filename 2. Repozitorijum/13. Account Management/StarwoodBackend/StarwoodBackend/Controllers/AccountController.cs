using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StarwoodBackend.Models;

namespace StarwoodBackend.Controllers
{
	[Route("api/account")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		[HttpPost("register")]
		public IActionResult Register(string username, string password, string firstname, string lastname)
		{
			if
			(
				string.IsNullOrWhiteSpace(username) ||
				string.IsNullOrWhiteSpace(password) ||
				string.IsNullOrWhiteSpace(firstname) ||
				string.IsNullOrWhiteSpace(lastname)
			)
			{
				return BadRequest();
			}

			var db = AppDbContext.Default;

			var query =
				from user in db.Users
				where user.Username == username
				select user;

			var usersFound = query.Count();

			if (usersFound > 0)
			{
				return BadRequest();
			}

			var newUser = new User
			{
				Username = username,
				Password = password,
				FirstName = firstname,
				LastName = lastname
			};

			db.Users.Add(newUser);
			db.SaveChanges();

			return Ok();
		}

		[HttpGet("authenticate")]
		public IActionResult Authenticate()
		{
			if (!AuthenticateClaims(Request)) return Unauthorized();

			return Ok();
		}

		public static bool AuthenticateClaims(HttpRequest request)
		{
			if (request.Headers.Authorization.Count == 0) return false;

			var auth = request.Headers.Authorization[0];

			if (!auth.StartsWith("Basic ")) return false;

			var encodedClaims = auth.Substring(6);
			var claims = Encoding.UTF8.GetString(Convert.FromBase64String(encodedClaims));

			var colonIndex = claims.IndexOf(':');
			if (colonIndex < 0) return false;

			var username = claims.Substring(0, colonIndex);
			var password = claims.Substring(colonIndex + 1);

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return false;

			var db = AppDbContext.Default;

			var query =
				from user in db.Users
				where user.Username == username && user.Password == password
				select user;

			return query.Count() == 1;
		}
	}
}
