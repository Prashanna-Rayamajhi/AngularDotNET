import { Component, OnInit } from '@angular/core';
import { MovieTheatersDTO } from 'src/app/model/movietheaters.model';
import { MovieTheaterService } from 'src/app/utilities/services/movietheaters.service';

@Component({
  selector: 'app-index-movie-theaters',
  templateUrl: './index-movie-theaters.component.html',
  styleUrls: ['./index-movie-theaters.component.css']
})
export class IndexMovieTheatersComponent implements OnInit {

  constructor(private movieTheaterService: MovieTheaterService) { }

  movieTheaters!: MovieTheatersDTO[];

  ngOnInit(): void {
   this.loadData();
  };
  loadData(){
    this.movieTheaterService.fetchMovieTheater().subscribe({
      next: (val) => this.movieTheaters = <MovieTheatersDTO[]> val
    });
  };
  delete(_id: number){
    this.movieTheaterService.deleteMovieTheater(_id).subscribe({
      next: () => this.loadData()
    })
  }

}
