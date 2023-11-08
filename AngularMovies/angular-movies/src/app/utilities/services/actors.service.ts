import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { ActorCreationDTO, ActorDTO } from "src/app/model/actor.model";
import { formatDateFormData } from "../FileHandling/files.toBase64";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { ActorMovieDTO } from "src/app/model/movie.model";

@Injectable({
    providedIn: 'root'
})
export class ActorService {
    private selectedActors: ActorDTO[] = [];
    public selectedActorsUpdated: Subject<ActorDTO[]> = new Subject<ActorDTO[]>();
    private actors: ActorDTO[] = [];
    //ctor
    /**
     *
     */
    constructor(private http: HttpClient) {
       
    }
    private apiURL = environment.apiURL + "/Actors"

    //working with API
    //adding actor into server(api)
    public AddActor(actor: ActorCreationDTO): Observable<any>{
        const formData = this.buildFormData(actor);
        return this.http.post(this.apiURL, formData);
    }
    //getting actors from api
    public fetchActors(page: number, recordsPerPage: number): Observable<any>{
        let params = new HttpParams().set("page", page)
        .set("pageSize", recordsPerPage);
        
        return this.http.get(this.apiURL, {observe: "response", params});
    }
    public fetchActorByID(id: number): Observable<any>{
        return this.http.get(`${this.apiURL}/${id}`);
    }
    //getiing actor by Name
    public searchActorByName(name: string): Observable<ActorMovieDTO[]>{
        const headers = new HttpHeaders("Content-Type: application/json");
        return this.http.post<ActorMovieDTO[]>(`${this.apiURL}/searchByName`, JSON.stringify(name), {headers});
    }
    //delete actors
    public deleteActor(id: number): Observable<any>{
        return this.http.delete(`${this.apiURL}/${id}`);
    }
    //edit actors
    public editActor(id:number, _actor: ActorCreationDTO): Observable<any>{
        
        const actor = this.buildFormData(_actor);
        return this.http.put(`${this.apiURL}/${id}`, actor);
    }

    //functions
    getAllActors(){
        return this.actors.slice();
    };

    getActorByID(id: number){
        if(id < 11 && id > 0){
            return this.actors.find((actor)=> actor.id === id);
        }
        return {id: 0, name: '', dateOfBirth: ''};
    };
    updateSelectedActor(_actor: ActorDTO, _isSelected: boolean){
        if(_isSelected){
            this.selectedActors.push(_actor)
        }
        if(!_isSelected){
            let index = this.selectedActors.findIndex(d => d.id == _actor.id);
            this.selectedActors.splice(index, 1);
        };
        this.selectedActorsUpdated.next(this.selectedActors);
    }

    //Helper functions
    private buildFormData(actor: ActorCreationDTO): FormData{
        const formData = new FormData();

        formData.append("name", actor.name);
        if(actor.biography){
            formData.append("biography", actor.biography);
        };
        if(actor.dateOfBirth){
            formData.append("dateOfBirth", formatDateFormData(actor.dateOfBirth));
        };
        if(actor.picture){
            formData.append("picture", actor.picture);
        }
        
        return formData;
    }


}