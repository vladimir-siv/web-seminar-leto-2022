import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MostPopularMovieComponent } from './most-popular-movie/most-popular-movie.component';
import { TrendingMoviesComponent } from './trending-movies/trending-movies.component';

@NgModule({
  declarations: [
    AppComponent,
    MostPopularMovieComponent,
    TrendingMoviesComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
