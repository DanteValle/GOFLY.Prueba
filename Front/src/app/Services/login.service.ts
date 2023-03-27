import { UserAuth } from './../Modelos/userAuth';
import { UserLogin } from '../Modelos/userLogin';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Router } from '@angular/router';

const httpOptions = {
  headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private loggedIn = false;
  private apiUrl = 'https://localhost:7100/api/Auth/login';
  private userSubject: BehaviorSubject<UserAuth|null>;// | null> = new BehaviorSubject<UserAuth | null>(null);
  public get userData(): UserAuth |null {
    return this.userSubject.value;
  }
  constructor(private http: HttpClient, private router: Router) {
    const userAuthString = localStorage.getItem('userAuth');
    //this.userSubject = new BehaviorSubject<UserAuth>(JSON.parse(userAuthString !=null? userAuthString:''));
    this.userSubject = new BehaviorSubject<UserAuth | null>(null);
    //userAuthString !=null? userAuthString:''
  }


  login(user: UserLogin): Observable<any> {

    return this.http.post<any>(this.apiUrl, user, httpOptions).pipe(
      map(res => {
        if (res != null) {
          const userAuth: UserAuth = res;
          localStorage.setItem('userAuth', JSON.stringify(userAuth));
          this.userSubject.next(userAuth);
          this.router.navigate(['/home']);
        }
        return res;
      })
    );
  }


  logout() {
    // Remueve el token del local storage
    localStorage.removeItem('userAuth');
    this.userSubject.next(null);
    // Establece loggedIn en false
    this.loggedIn = false;
    // Redirige al usuario a la página de inicio de sesión después de cerrar sesión
    this.router.navigate(['/login']);
  }

  isLoggedIn() {
    // Verifica si el usuario está autenticado
    return this.loggedIn;
  }

  getToken() {
    // Obtiene el token del local storage
    return localStorage.getItem('userAuth');
  }
}
