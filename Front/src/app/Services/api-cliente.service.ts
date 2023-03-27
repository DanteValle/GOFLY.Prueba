import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiClienteService {
  apiUrl = 'http://localhost:7180/api/Item';
  constructor(private http: HttpClient) { }

 
}
