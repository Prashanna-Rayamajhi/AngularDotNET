import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import {Injectable} from "@angular/core";
import { Observable } from "rxjs";
import { userDTO } from "src/app/model/user.model";
import { AuthenticationResponse, UserCredential } from "src/app/model/usercredential.model";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: "root"
})
export class SecurityService{

    constructor(private http: HttpClient){}
    private apiURL = environment.apiURL + "/User";
    private readonly token : string = "token-key";
    private readonly expiration : string = "token-expiration";
    private readonly role : string = "role" 

    public isAuthenticated(): boolean {
        const token = localStorage.getItem(this.token);
        if(!token){
            return false;
        }
        const expiration = <string>localStorage.getItem(this.expiration);
        const expirationDate = new Date(expiration);
        if(expirationDate <= new Date()){
            this.logout();
            return false;   
        }
        return true;
    }
    getFieldFromJwt(field: string): string{
        const token = localStorage.getItem(this.token);
        if(!token){
            return "";
        }
        const dataToken = JSON.parse(atob(token.split(".")[1]))
        
        return dataToken[field];
    }
    logout(){
        localStorage.removeItem(this.token);
        localStorage.removeItem(this.expiration);
    }
    public getToken(){
        return localStorage.getItem(this.token);
    }
    public getRole(): string{
        const role =  this.getFieldFromJwt(this.role);
        return role;
    }

    public registerUser(_credential: UserCredential): Observable<AuthenticationResponse>{
        return this.http.post<AuthenticationResponse>(this.apiURL + "/create", _credential);
    }
    public loginUser(_credential: UserCredential): Observable<AuthenticationResponse>{
        return this.http.post<AuthenticationResponse>(this.apiURL + "/login", _credential);
    }

    public saveToken(authResponseToken: AuthenticationResponse){
        localStorage.setItem(this.token, authResponseToken.token);
        localStorage.setItem(this.expiration, authResponseToken.expiration.toString());  
    }
    public getUsers(page: number, pageSize: number): Observable<any>{
        let params = new HttpParams().set("page", page).set("pageSize", pageSize);

        return this.http.get<userDTO[]>(`${this.apiURL}/usersList`, {observe: "response", params});
    }
    public makeAdmin(userId: string){
        const headers = new HttpHeaders("Content-Type: application/json")
        return this.http.post(`${this.apiURL}/makeAdmin`, JSON.stringify(userId), {headers});
    }
    public removeAdmin(userId: string){
        const headers = new HttpHeaders("Content-Type: application/json")
        return this.http.post(`${this.apiURL}/removeAdmin`, JSON.stringify(userId), {headers});
    }

}