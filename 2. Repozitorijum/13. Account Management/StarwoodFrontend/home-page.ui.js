function display(movies)
{
	const table = document.getElementById("movies");
	table.innerHTML = "";

	for (const movie of movies)
	{
		let genres = "";
		genres += "<ul>";
		for (const genre of movie.genres)
			genres += "<li>" + genre.name + " / " + genre.ratio + "</li>";
		genres += "</ul>";

		table.innerHTML +=
			"<tr>" +
				"<td>" + movie.id + "</td>" +
				"<td>" + movie.name + "</td>" +
				"<td>" + genres + "</td>" +
			"</tr>"
			;
	}
}
