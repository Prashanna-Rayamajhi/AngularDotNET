import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MultipleSelectorVM } from 'src/app/ViewModel/multiple-selector.vm';
import { MovieCreationDTO } from 'src/app/model/movie.model';
import { MoviesServvice } from 'src/app/utilities/services/movies.service';

@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.css']
})
export class CreateMovieComponent implements OnInit {

  constructor(private movieService: MoviesServvice, private router: Router) { }

  
  ngOnInit(): void {
    
  }

  onSaveChanges(_movie: MovieCreationDTO){
    this.movieService.addMovie(_movie).subscribe(()=>{
      this.router.navigate([""]);
    });
  }

}
