import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Venta } from '../models/venta';
import { Response } from '../models/response';
import { Observable } from 'rxjs';

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type':'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ApiventaService {

  url:string ='https://localhost:44319/api/Venta';

  constructor(
    private _http: HttpClient
  ) { }

  add(venta:Venta): Observable<Response>{
    console.log("venta", venta);
    return this._http.post<Response>(this.url,venta, httpOption);

  }
}
