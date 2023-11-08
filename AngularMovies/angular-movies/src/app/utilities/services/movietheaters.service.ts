import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";


import { MovieTheaterCreationDTO, MovieTheatersDTO } from "src/app/model/movietheaters.model";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: "root"
})
export class MovieTheaterService {
  
    private movieTheaters: MovieTheatersDTO[] = [ 
    ]
    
    public movieTheaterOfMovieUpdated: Subject<number[]> = new Subject<number[]>();
    /**
     *
     */
    constructor(private http: HttpClient) { 
        this.fetchMovieTheater().subscribe(val => this.movieTheaters = val)
    }
    //working with API's
    private apiURL: string = environment.apiURL + '/MovieTheater';
    
    //create functionality
    public addMovieTheater(_movieTheater: MovieTheaterCreationDTO): Observable<any>{
        return this.http.post(this.apiURL, _movieTheater);
    }
    //get functionality
    public fetchMovieTheater(): Observable<any>{
        return this.http.get(this.apiURL);
    }
    //get By ID functionality;
    public fecthMovieTheaterByID(_id: number): Observable<any>{
        return this.http.get(`${this.apiURL}/${_id}`);
    }
    //edit action with api
    public editMovieTheater(_id: number, _movieTheater: MovieTheaterCreationDTO): Observable<any>{
        return this.http.put(`${this.apiURL}/${_id}`, _movieTheater);
    }
    //delete Action with api
    public deleteMovieTheater(_id:number): Observable<any>{
        return this.http.delete(`${this.apiURL}/${_id}`);
    }

    public getAllMovieTheaters(){
        return this.movieTheaters.slice();
    }
    // public getMovieTheatersByID(_ids: number[]){
    //     _ids.forEach(_id => {
    //         const movieTheater =  this.movieTheaters.find(mt => mt.id == _id);
    //         if(movieTheater != undefined) {
    //             this.movieTheatersCordinates = movieTheater.coordinates;
    //             this.selectedMovieTheaters.push(movieTheater);
    //             this.movieTheaterCordinate.next(this.movieTheatersCordinates);
    //         }
    //     })
    //     return this.selectedMovieTheaters;
    // }
    public getMovieTheaterByName(movieTheater: string){
        let filteredResult: MovieTheatersDTO[] = []
        if(movieTheater){
            this.movieTheaters.forEach(movieTh => {
                if(movieTh.name.toUpperCase().includes(movieTheater.toUpperCase())) filteredResult.push(movieTh)
            });
           // this.moviesFiltered.next(filteredResult);
           return filteredResult;
        }
       // if(movieTheater === '') this.moviesFiltered.next(this.getAllMovies());
       return this.getAllMovieTheaters();
    }
  
   
}