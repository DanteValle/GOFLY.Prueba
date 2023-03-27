import { HttpBackend,HttpClient  } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from '../Modelos/Item';
//import { Agent } from 'https';

@Injectable({
  providedIn: 'root'
})
export class ApiProductoService {
  apiUrl = 'https://localhost:7180/api/Item';
  constructor(private http: HttpClient) { }
  getAllProducts(): Observable<any> {
    return this.http.get<any>(this.apiUrl+"/GetAllItems");
  }
  
}

