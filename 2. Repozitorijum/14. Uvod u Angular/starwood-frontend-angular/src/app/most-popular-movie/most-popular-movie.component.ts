import { Component, OnInit } from '@angular/core';

@Component
({
  selector: 'most-popular-movie',
  templateUrl: './most-popular-movie.component.html',
  styleUrls: ['./most-popular-movie.component.css']
})
export class MostPopularMovieComponent implements OnInit
{
  mostPopularMovie: string = "";

  constructor() { }
  ngOnInit(): void { }

  showMostPopularMovie()
  {
    const request = fetch('http://localhost:5135/api/movies-v5/most-popular');
    request.then
    (
      (response) =>
      {
        const body = response.json();
        body.then
        (
          (movie) =>
          {
            this.mostPopularMovie = movie.name;
          }
        );
      }
    );
  }
}
