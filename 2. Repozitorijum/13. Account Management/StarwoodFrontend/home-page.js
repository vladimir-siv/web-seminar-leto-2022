window.onload = function main()
{
	const username = sessionStorage.getItem("username");

	if (username != null)
	{
		const greetLabel = document.getElementById("user-greet");
		greetLabel.innerHTML = "Welcome, " + username;
	}
	else window.location.replace("index.html");
}

function logout()
{
	sessionStorage.clear();
	window.location.replace("index.html");
}

function onMostPopularMovieClick()
{
	const username = sessionStorage.getItem("username");
	const password = sessionStorage.getItem("password");

	const request = fetch
	(
		'http://localhost:5135/api/movies-v6/most-popular',
		{
			headers:
			{
				Authorization: "Basic " + btoa(username + ":" + password)
			}
		}
	);

	request.then
	(
		function callback(response)
		{
			const body = response.json();
			body.then
			(
				function callback(movie)
				{
					display([movie]);
				}
			);
		}
	);
}

function onTrendingMoviesClick()
{
	const username = sessionStorage.getItem("username");
	const password = sessionStorage.getItem("password");

	const count = parseInt(document.getElementById("count").value);
	const qsp = "?count=" + count;

	const request = fetch
	(
		'http://localhost:5135/api/movies-v6/trending' + qsp,
		{
			headers:
			{
				Authorization: "Basic " + btoa(username + ":" + password)
			}
		}
	);


	request.then
	(
		function callback(response)
		{
			const body = response.json();
			body.then
			(
				function callback(movies)
				{
					display(movies);
				}
			);
		}
	);
}
