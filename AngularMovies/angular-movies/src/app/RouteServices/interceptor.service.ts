import {Injectable} from "@angular/core"
import { SecurityService } from "../utilities/services/security.service";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn : "root"
})
export class JwtInterceptor implements HttpInterceptor{

    constructor(private securityService: SecurityService){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        const token = this.securityService.getToken();

        if(token){
            req = req.clone({
                setHeaders: {Authorization : `Bearer ${token}`}
            });
        }
        return next.handle(req);
    }

}