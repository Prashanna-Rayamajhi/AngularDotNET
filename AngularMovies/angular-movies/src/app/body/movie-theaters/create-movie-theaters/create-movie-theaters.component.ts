import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MovieCreationDTO } from 'src/app/model/movie.model';
import { MovieTheaterCreationDTO } from 'src/app/model/movietheaters.model';
import { MovieTheaterService } from 'src/app/utilities/services/movietheaters.service';

@Component({
  selector: 'app-create-movie-theaters',
  templateUrl: './create-movie-theaters.component.html',
  styleUrls: ['./create-movie-theaters.component.css']
})
export class CreateMovieTheatersComponent implements OnInit {

  constructor(private movieTheaterService: MovieTheaterService, private router: Router) { }

  ngOnInit(): void {
  }
  OnSaveChanges(_movieTheater : MovieTheaterCreationDTO){
    //console.log(_movieTheater);
    this.movieTheaterService.addMovieTheater(_movieTheater).subscribe({
      next: () => this.router.navigate(["/movietheaters"])
    })

  }

}
