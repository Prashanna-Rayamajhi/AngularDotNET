import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GenreDTO } from 'src/app/model/genre.model';
import { ActorMovieDTO, Movie, MovieCreationDTO } from 'src/app/model/movie.model';
import { MovieTheatersDTO } from 'src/app/model/movietheaters.model';
import { MoviesServvice } from 'src/app/utilities/services/movies.service';
import { MultiSelectionService } from 'src/app/utilities/services/multi-selector.service';



@Component({
  selector: 'app-form-movie',
  templateUrl: './form-movie.component.html',
  styleUrls: ['./form-movie.component.css']
})
export class FormMovieComponent implements OnInit {
  contentType="Summary";
  @Input() model: Movie | undefined;
  @Output() onSaveChanges = new EventEmitter<MovieCreationDTO>(); 

 //genres and theaters associated with models
  modelGenre: GenreDTO[] = [];
  modelTheaters: MovieTheatersDTO[] = [];
  modelActors: ActorMovieDTO[] = [];
  
  
  constructor(private formBuilder: FormBuilder, private multiSelectorService: MultiSelectionService) { }


  form!: FormGroup;
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', {
        validators: [Validators.required, ]
      }],
      releaseDate: '',
      summary: '',
      poster: '',
      moviesInTheaters: false,
      inFutureRelease: false,
      trailer: '',
      genreIDs: '', 
      theaterIDs : '',
      actors: ''
    })
    if(this.model != undefined){
      this.form.patchValue(this.model);
      this.form.get("releaseDate")?.patchValue(new Date(this.model.releaseDate));

      this.modelGenre = this.model.genres;
      this.modelTheaters = this.model.movieTheaters;
      this.modelActors = this.model.actors;

      this.multiSelectorService.AddSelectedDataOFModel(this.modelGenre, this.modelTheaters, this.modelActors);
    }
    this.multiSelectorService.genreUpdated.subscribe({
      next: repsonse => this.modelGenre = <GenreDTO[]>repsonse
    });
    this.multiSelectorService.theaterUpdated.subscribe({
      next: (response) => this.modelTheaters = <MovieTheatersDTO[]>response
    });
    this.multiSelectorService.actorMovieUpdated.subscribe({
      next: response => this.modelActors = response
    })
    
    
  };


  OnSaveChanges(){
     const genreIDs = this.modelGenre.map(genre => genre.id);
     this.form.get('genreIDs')?.patchValue(genreIDs);
     const theaterIDs = this.modelTheaters.map(theater => theater.id);
     this.form.get('theaterIDs')?.patchValue(theaterIDs);
    const actors = this.modelActors.map(actor => {
      return {id: actor.id, character: actor.character};
    });
    this.OnImageSelected(this.form.get("poster")?.value);
    this.form.get("actors")?.patchValue(actors);
    
    this.onSaveChanges.emit(this.form.value);
    
  }
  OnImageSelected(file: File){
    this.form.get('poster')?.setValue(file);
  }
  OnChangeMarkdown(contentSummary: string){
    this.form.get('summary')?.patchValue(contentSummary);
  }

}
 

