import {Injectable} from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { SecurityService } from "../utilities/services/security.service";

@Injectable({
    providedIn:"root"
})

export class AuthGaurd implements CanActivate {

    constructor(private router: Router, private securityservice: SecurityService){}
    canActivate(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | UrlTree | Promise<boolean> | boolean{
        if(this.securityservice.getRole() == "admin"){
            return true;
        }
        this.router.navigate(["/login"]);
        return false;
    }
   

}