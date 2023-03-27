import { LoginService } from './../Services/login.service';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor{

    constructor(private loginService: LoginService){}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const userAuth = this.loginService.userData;
        if (userAuth) {
            req = req.clone({
                setHeaders:{
                    Authorization: `Bearer ${userAuth.token}`
                }
            });
        }
      return next.handle(req);
    }
}