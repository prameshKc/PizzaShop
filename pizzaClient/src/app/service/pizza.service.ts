import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Pizza } from '../models/pizza-model';
import { Pizzeria } from '../models/pizzeria-model';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  env = environment;
  constructor(private _http: HttpClient) { }

  getPizzas(): Observable<Pizza[]> {
    return this._http.get<Pizza[]>(`${this.env.apiUrl}/Pizza/getAllPizzas`)
  }

  getPizzaById(id:number): Observable<Pizza> {
    return this._http.get<Pizza>(`${this.env.apiUrl}/Pizza/getById/${id}`)
  }
}
