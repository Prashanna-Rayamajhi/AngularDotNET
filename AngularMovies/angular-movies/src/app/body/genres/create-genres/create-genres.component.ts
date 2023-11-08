
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GenreCreationDTO, GenreDTO} from 'src/app/model/genre.model';
import { parseWebApiErrors } from 'src/app/utilities/FileHandling/files.toBase64';
import { GenreService } from 'src/app/utilities/services/genres.service';


@Component({
  selector: 'app-create-genres',
  templateUrl: './create-genres.component.html',
  styleUrls: ['./create-genres.component.css']
})
export class CreateGenresComponent implements OnInit {

  errors: string[] = [];
 // genres: GenreDTO[] = [];
 
  constructor(private router: Router, private genreService: GenreService ) { }

  ngOnInit(): void {
    
  }
  OnSaveChange(genre: GenreCreationDTO){
    //this.genres = this.genreService.getAllGenres();


    this.genreService.addGenre(genre).subscribe({
      next: () => this.router.navigate(['/genres']),
      error: (err) => this.errors = parseWebApiErrors(err)
    });

  
  }
  
}
