import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseUrlService } from './base-url.service';
import { Observable } from 'rxjs';
import { LoginServicesService } from './login-services.service';
import { Ilogs } from '../Interfaces/ilogs';

@Injectable({
  providedIn: 'root'
})
export class LogServicesService {

  constructor(private _HttpClient : HttpClient, private _BaseUrlService : BaseUrlService , private _LoginServicesService : LoginServicesService) { }

  private baseUrl : string =  `${this._BaseUrlService.BasUrl}api/Log`;

  getLogs () : Observable<any>
  {
    return this._HttpClient.get(this.baseUrl);
  }

  addLog(note : string ) : Observable<any> 
  {
    const log : Ilogs = {
      id : 0,
      username : this._LoginServicesService.decodeUserToken.getValue()["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"],
      email: this._LoginServicesService.decodeUserToken.getValue()["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
      note : note,
      data : ""
    };
    return this._HttpClient.post(this.baseUrl,log)
  }
}
