import { Component, OnInit } from '@angular/core';

@Component
({
  selector: 'trending-movies',
  templateUrl: './trending-movies.component.html',
  styleUrls: ['./trending-movies.component.css']
})
export class TrendingMoviesComponent implements OnInit
{
  trendingMovies: any[] = [];

  constructor() { }
  ngOnInit(): void { }

  showTrendingMovies()
  {
    const request = fetch('http://localhost:5135/api/movies-v5/trending');
    request.then
    (
      (response) =>
      {
        const body = response.json();
        body.then
        (
          (movies) =>
          {
            this.trendingMovies = movies;
          }
        );
      }
    );
  }
}
