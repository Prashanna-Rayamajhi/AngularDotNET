import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie, MovieCreationDTO } from 'src/app/model/movie.model';
import { MoviesServvice } from 'src/app/utilities/services/movies.service';

@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.css']
})
export class EditMovieComponent implements OnInit {
  model!: Movie;

  constructor(private movieService: MoviesServvice, private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(param =>{
       this.movieService.getMovieByID(+param['id']).subscribe({
        next: val => this.model = val
       })
    })
  }
  onSaveChanges(_movie: MovieCreationDTO){
    this.movieService.editMovie(this.model.id, _movie).subscribe({
      next: () => this.router.navigate(["/movies/"+this.model.id])
    })
  }

}
