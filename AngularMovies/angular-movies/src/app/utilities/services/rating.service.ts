import { HttpClient } from "@angular/common/http";
import {Injectable} from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: "root"
})

export class RatingService{
    constructor(private http: HttpClient){}
    private apiURL = environment.apiURL + "/Rating"

    public rate(movieID:number, rating: number): Observable<any>{
      return  this.http.post(this.apiURL, {movieID: movieID, rate: rating});
    }
}