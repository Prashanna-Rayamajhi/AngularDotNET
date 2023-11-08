import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,  Router } from '@angular/router';
import { GenreCreationDTO, GenreDTO } from 'src/app/model/genre.model';
import { parseWebApiErrors } from 'src/app/utilities/FileHandling/files.toBase64';
import { GenreService } from 'src/app/utilities/services/genres.service';

@Component({
  selector: 'app-edit-genre',
  templateUrl: './edit-genre.component.html',
  styleUrls: ['./edit-genre.component.css']
})
export class EditGenreComponent implements OnInit {

  constructor(private genreService: GenreService, 
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  model!: GenreDTO;
  errors: string[] = []; 
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(param =>{
       this.genreService.getGenreByID(+param["id"]).subscribe({
        next: (val)=> this.model = <GenreDTO>val
       });
    })
  }
  OnSaveChange(genre: GenreCreationDTO){
    this.genreService.updateGenre(this.model.id, genre).subscribe(
      {
      next: () => this.router.navigate(['/genres']),
      error: (err) => this.errors = parseWebApiErrors(err)
      })
  }
}
