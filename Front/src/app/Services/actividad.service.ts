import { User } from './../Modelos/User';
import { Activity } from './../Modelos/Activity';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ActividadService {

  apiUrl = 'https://localhost:7100/api/Activity';
  constructor(private http: HttpClient) { }

  obtenerActividades(): Observable<any> {
    return this.http.get<any>(this.apiUrl+"/GetAllActivitiesWithUser");
  }
  crearActividad(activity: Activity): Observable<any> {
    return this.http.post<Activity>(this.apiUrl+"/CreateActivity",activity);
  }
  modificarActividad(activity: Activity): Observable<any> {
    return this.http.put<Activity>(this.apiUrl+"/UpdateActivity",activity);
  }
  eliminarActividad(idActivity: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/DeleteActivity/${idActivity}`);
  }
}
