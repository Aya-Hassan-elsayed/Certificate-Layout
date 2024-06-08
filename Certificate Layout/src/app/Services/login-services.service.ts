import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { jwtDecode } from "jwt-decode";
import { Router } from '@angular/router';
import { BaseUrlService } from './base-url.service';

@Injectable({
  providedIn: 'root'
})
export class LoginServicesService {

  constructor(private _HttpClient : HttpClient , private _Router: Router , private _BaseUrlService : BaseUrlService)
  {
    if(this.decodeUserToken.getValue() != null)
    {
      this.SaveToken();
    }
  }

  baseUrl = `${this._BaseUrlService.BasUrl}api/Aut`;
  decodeUserToken : any  = new BehaviorSubject(null);


  tryLogin(Data : any) : Observable<any>
  {
    return this._HttpClient.post(`${this.baseUrl}/Login`,Data)
  }
  
  Register(Data : any) : Observable<any>
  {
    return this._HttpClient.post(`${this.baseUrl}/Register`,Data)
  }

  SaveToken()
  {
    this.decodeUserToken.next(jwtDecode(JSON.stringify(localStorage.getItem("userToken"))));
  }
}
