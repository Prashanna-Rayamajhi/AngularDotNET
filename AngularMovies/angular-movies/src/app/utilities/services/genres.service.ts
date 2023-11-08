import { Injectable } from "@angular/core";
import {HttpClient} from "@angular/common/http"

import { Observable, Subject } from "rxjs";
import { GenreCreationDTO, GenreDTO } from "src/app/model/genre.model";
import { environment } from "src/environments/environment";
import { parseWebApiErrors } from "../FileHandling/files.toBase64";


@Injectable({
  providedIn: 'root',
})
export class GenreService { 
   
 
  private genres: GenreDTO[] = [];
  //API URL
  private apiURL = environment.apiURL + '/Genre';

  //constructor method
  /**
   *
   */
  constructor(private http: HttpClient) {
    this.fetchDataFromAPI().subscribe({
      next: value => {
        this.setGenresLocally(<GenreDTO[]>value)     
      },
      
    })
  
  }

 //API Connection
 public fetchDataFromAPI(): Observable<any>{
  return this.http.get(this.apiURL);
 }
 //adding data in API
 public addGenre(genre: GenreCreationDTO): Observable<GenreDTO>{
  return <Observable<GenreDTO>>this.http.post(this.apiURL, genre)
}

//getting Genre By ID
public getGenreByID(id: number): Observable<any>{
  return <Observable<GenreDTO>> this.http.get(`${this.apiURL}/${id}`);
}
//updating the genre
public updateGenre(id: number, genre: GenreCreationDTO){
  return this.http.put(`${this.apiURL}/${id}`, genre); 
}
//deleting the genre
public deleteGenre(id: number){
  return this.http.delete(`${this.apiURL}/${id}`);  
}

//Set Data locally
 public setGenresLocally(genres: GenreDTO[]): void{
  this.genres = genres;
 }
  /////
}