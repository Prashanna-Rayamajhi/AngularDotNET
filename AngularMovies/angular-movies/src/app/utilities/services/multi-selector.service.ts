import { GenreDTO } from "src/app/model/genre.model";
import { MovieTheatersDTO } from "src/app/model/movietheaters.model";
import { GenreService } from "./genres.service";
import { MovieTheaterService } from "./movietheaters.service";
import{ Injectable} from "@angular/core"
import { Subject } from "rxjs";
import { ActorMovieDTO } from "src/app/model/movie.model";

@Injectable({
    providedIn: "root"
})
export class MultiSelectionService{
    public genreUpdated: Subject<GenreDTO[]> = new Subject<GenreDTO[]>();
    public theaterUpdated: Subject<MovieTheatersDTO[]>= new Subject<MovieTheatersDTO[]>();
    public actorMovieUpdated: Subject<ActorMovieDTO[]> = new Subject<ActorMovieDTO[]>();
    /**
     *
     */
    constructor(private genreService: GenreService, private theaterService: MovieTheaterService) {
        
        
    }
     //private fields
     private selectedGenreOfMovie: GenreDTO[] = [];
     private slectedTheaterOfMovie: MovieTheatersDTO[] = [];
     private selectedActors : ActorMovieDTO[] = [];
     
     public updateSelectedGenre(_genreID: number, isSelected: boolean){
        if(isSelected){
            this.genreService.getGenreByID(_genreID).subscribe((response) =>{
                this.selectedGenreOfMovie.push({id: response.id, name: response.name});
            })
        }
        if(!isSelected){
            const index = this.selectedGenreOfMovie.findIndex(genre => genre.id == _genreID);
            this.selectedGenreOfMovie.splice(index, 1);
        }
        this.genreUpdated.next(this.selectedGenreOfMovie);
        
     }
     public updateSelectedTheater(_theaterID: number, isSelected: boolean){
        if(isSelected){
            this.theaterService.fecthMovieTheaterByID(_theaterID).subscribe((theater) => {
                this.slectedTheaterOfMovie.push({id: theater.id, name: theater.name, longtitude: theater.longtitude, latitude: theater.latitude});
            });
        }
        if(!isSelected){
            const index = this.slectedTheaterOfMovie.findIndex(theater => theater.id == _theaterID);
            this.slectedTheaterOfMovie.splice(index, 1);
        }
        this.theaterUpdated.next(this.slectedTheaterOfMovie);
        
     }
     public updateActorMovie(_actor: ActorMovieDTO, isSelected: boolean){
        if(isSelected){
            const index = this.selectedActors.findIndex(actor => actor.id == _actor.id);
            if( index != -1){
                this.selectedActors.splice(index, 1);
                this.selectedActors.push(_actor);
            }else{
                this.selectedActors.push(_actor);
            }
            
        }
        if(!isSelected){
            let index = this.selectedActors.findIndex(actor => actor.id == _actor.id);
            this.selectedActors.splice(index, 1);
        }
        
        this.actorMovieUpdated.next(this.selectedActors);
     }

     public AddSelectedDataOFModel(_selectedgenre: GenreDTO[], _selectedTheater: MovieTheatersDTO[], _selectedActors: ActorMovieDTO[]){
        this.selectedGenreOfMovie = _selectedgenre;
        this.slectedTheaterOfMovie = _selectedTheater;
        this.selectedActors = _selectedActors;
     }
}