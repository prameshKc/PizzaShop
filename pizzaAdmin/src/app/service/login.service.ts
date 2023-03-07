import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PizzeriaUserLogin } from '../models/user-login-model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  env = environment;
  constructor(private _http: HttpClient) { }

  LoginUser(login:PizzeriaUserLogin): Observable<any> {
    return this._http.post<HttpResponse<any>>(`${this.env.apiUrl}/Login/login`,login,{
      observe:'response'
    });
  }

}
