import { Sale } from './../Modelos/Sale';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VentaService {
  apiUrl = 'https://localhost:7180/api/Sale';
  constructor(private http: HttpClient) { }

  getAllSale(): Observable<any> {
    return this.http.get<any>(this.apiUrl+"/GetAllSale");
  }
  createSale(sale: Sale): Observable<any> {
    return this.http.post<Sale>(this.apiUrl+"/CreateSale",sale);
  }
  
}
