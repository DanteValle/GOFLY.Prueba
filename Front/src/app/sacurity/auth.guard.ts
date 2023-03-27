import { LoginService } from './../Services/login.service';
import { Injectable } from '@angular/core';
import {Router, CanActivate,ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from 'rxjs';
@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate{
    constructor(private router: Router, private loginService: LoginService){

    }
    canActivate(route: ActivatedRouteSnapshot) {
        const userAuth = this.loginService.userData;
        if (userAuth) {
            return true;
        }
        this.router.navigate(['/login']);
        return false;
    }
}