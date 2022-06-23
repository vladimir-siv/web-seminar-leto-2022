import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MostPopularMovieComponent } from './most-popular-movie.component';

describe('MostPopularMovieComponent', () => {
  let component: MostPopularMovieComponent;
  let fixture: ComponentFixture<MostPopularMovieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MostPopularMovieComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MostPopularMovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
