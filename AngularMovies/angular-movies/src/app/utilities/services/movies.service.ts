import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { HomeDTO, Movie, MovieCreationDTO, MoviePostGetDTO} from "src/app/model/movie.model";
import { environment } from "src/environments/environment";
import { formatDateFormData } from "../FileHandling/files.toBase64";

@Injectable(
    {providedIn: 'root'}
)
export class MoviesServvice {
    

    private movies : Movie[] = [];

    
//////////////////////////
/**
 *
 */
  constructor(private http: HttpClient) {
  
  }
    //Working with APIS
    private apiURL = environment.apiURL + "/Movie";

    //making api request
    //POSTGET request
    public fetchPostGet(): Observable<MoviePostGetDTO>{
      return this.http.get<MoviePostGetDTO>(`${this.apiURL}/PostGet`);
    }

    public getMovies(): Observable<HomeDTO>{
      return this.http.get<HomeDTO>(this.apiURL);
    }

    public editMovie(_id:number,_movieEdited: MovieCreationDTO): Observable<any>{
      const movie = this.formBuilder(_movieEdited)
      return this.http.put(`${this.apiURL}/${_id}`, movie);
    }

    public addMovie(movieCreation: MovieCreationDTO){
    
      const movie = this.formBuilder(movieCreation);

      return this.http.post(this.apiURL, movie);
    }

    public getMovieByID(_id: number): Observable<Movie>{
      return <Observable<Movie>> this.http.get(this.apiURL + `/${_id}`)
    }

    public filter(value: any): Observable<any>{
      const params = new HttpParams({fromObject: value});
      return this.http.get<Movie[]>(`${this.apiURL}/Filter`, {params, observe: "response"});
    }

    public deleteMovie(_id: number): Observable<any>{
      return this.http.delete(`${this.apiURL}/${_id}`);
    }

//////////////////////
    private formBuilder(movie: MovieCreationDTO): FormData{
      const formData = new FormData();

      formData.append("name", movie.name);
      formData.append("summary", movie.summary);
      formData.append("trailer", movie.trailer);
      formData.append("inTheaters", String(movie.moviesInTheaters))
      if(movie.releaseDate){
        formData.append("releaseDate", formatDateFormData(movie.releaseDate));
      }
      if(movie.poster){
        formData.append("poster", movie.poster);
        
      }
      formData.append("genreIDs", JSON.stringify(movie.genreIDs));
      formData.append("movieTheaterIDs", JSON.stringify(movie.theaterIDs));
      formData.append("movieActors", JSON.stringify(movie.actors));

      return formData;
    }

  

   

   

   
}