import { User } from './../Modelos/User';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  apiUrl = 'https://localhost:7100/api/User';
  constructor(private http: HttpClient) { }

  obtenerUsuarios(): Observable<any> {
    return this.http.get<any>(this.apiUrl+"/GetAllUser");
  }
  crearUsuario(user: User): Observable<any> {
    return this.http.post<User>(this.apiUrl+"/CreateUser",user);
  }
  modificarUsuario(user: User): Observable<any> {
    return this.http.put<User>(this.apiUrl+"/UpdateUser",user);
  }
  eliminarUsuario(idUser: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/DeleteUser/${idUser}`);
  }
}
