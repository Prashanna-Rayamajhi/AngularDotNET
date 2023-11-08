import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { MovieTheaterCreationDTO, MovieTheatersDTO } from 'src/app/model/movietheaters.model';
import { MovieTheaterService } from 'src/app/utilities/services/movietheaters.service';

@Component({
  selector: 'app-edit-movie-theater',
  templateUrl: './edit-movie-theater.component.html',
  styleUrls: ['./edit-movie-theater.component.css']
})
export class EditMovieTheaterComponent implements OnInit {
 model!: MovieTheatersDTO;
  constructor(private activatedRoute: ActivatedRoute, 
    private movieTheatersService: MovieTheaterService,
    private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(
      (param) =>{
        this.movieTheatersService.fecthMovieTheaterByID(+param['id']).subscribe({
          next: (val) => {
            this.model = val;
          }
        });
      }
    )
  };
  OnSaveChanges(movieTheater: MovieTheaterCreationDTO){
    this.movieTheatersService.editMovieTheater(this.model.id, movieTheater).subscribe({
      next: () => this.router.navigate(['/movietheaters'])
    })
  }

}
