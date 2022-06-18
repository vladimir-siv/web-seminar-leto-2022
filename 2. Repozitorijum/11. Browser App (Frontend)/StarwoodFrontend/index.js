function onMostPopularMovieClick()
{
	const request = fetch('http://localhost:5135/api/movies-v4/most-popular');
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
	const count = parseInt(document.getElementById("count").value);
	const qsp = "?count=" + count;

	const request = fetch('http://localhost:5135/api/movies-v4/trending' + qsp);
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
