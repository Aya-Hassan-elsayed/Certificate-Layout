import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { BaseUrlService } from './base-url.service';


@Injectable({
  providedIn: 'root'
})
export class UserServicesService {

  constructor(private _HttpClient : HttpClient, private _BaseUrlService : BaseUrlService) { }
  headers : any = new HttpHeaders({
    'Content-Type': 'application/json' // Set your desired content type
  });

  private baseUrl : string =  `${this._BaseUrlService.BasUrl}api/User`;

  userID : string = "";
  userEmail : string = "";


  getUsers(CompanyName : string | null) : Observable<any>
  {
    if (CompanyName !== null && CompanyName !== '') {
      return this._HttpClient.get(`${this.baseUrl}?CompanyName=${CompanyName}`);
    } else {
      return this._HttpClient.get(this.baseUrl);
    }

  }

  deleteUser() : Observable<any>
  {
    return this._HttpClient.delete(`${this.baseUrl}/${this.userID}`);
  }

  addCertificates(certificates : FormData) : Observable<any>
  {
    return this._HttpClient.post(this.baseUrl, certificates)
  }

  getUserData() :Observable<any>
  {
    return this._HttpClient.get(`${this.baseUrl}/${this.userID}`);
  }

  addRoleForUser(data : any) : Observable<any>
  {
    return this._HttpClient.post(`${this.baseUrl}/AddRole` ,data)
  }
  Edit(data : any) : Observable<any>
  {
    return this._HttpClient.put(this.baseUrl ,data)
  }
  changePassword(data: any): Observable<any> {

    return this._HttpClient.put(`${this.baseUrl}/password`, data, { headers: this.headers });
  }
  resetPassword(data: any): Observable<any> {

    return this._HttpClient.post(`${this.baseUrl}/resetpassword`, data, { headers: this.headers });
  }
}
