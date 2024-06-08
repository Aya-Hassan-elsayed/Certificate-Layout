import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BaseUrlService } from './base-url.service';
import { Observable } from 'rxjs';
import { ICertificateLayout } from '../Interfaces/icertificate-layout';

@Injectable({
  providedIn: 'root'
})
export class CertificateServicesService {

  constructor(private _HttpClient : HttpClient , private _Router: Router , private _BaseUrlService : BaseUrlService){  }
  Data: ICertificateLayout = {} as ICertificateLayout;
  certificateGrageValue : number = 0;
  baseUrl = `${this._BaseUrlService.BasUrl}api/CertificateLayout`;
  certificateRequestNumber : any = ""; 
  type : boolean = false;
  isEditEnable : boolean = false;
  headers : any = new HttpHeaders({
    'Content-Type': 'application/json' // Set your desired content type
  });
  
  getNewCertificates(Data : any) : Observable<any>
  {
    return this._HttpClient.post(`${this.baseUrl}/GetNewData`,Data, { headers: this.headers })
  }
  getEditCertificates(Data : any) : Observable<any>
  {
    return this._HttpClient.post(`${this.baseUrl}/GetEditData`,Data, { headers: this.headers })
  }
  TakeScreenShot() : Observable<any>
  {
    return this._HttpClient.get(`${this.baseUrl}/convertImage`)
  }

  getCertificateInformation () :  Observable<any>
  {
    if (this.type) {
      
      return this._HttpClient.get(`${this.baseUrl}/EditCertificateInformations?ShipingOdeder=${this.certificateRequestNumber}`)
    }
    else
    {
      return this._HttpClient.get(`${this.baseUrl}/CertificateInformations?Requestnumber=${this.certificateRequestNumber}`)
    }

  }

  getUnitType() : Observable<any> 
  {
    return this._HttpClient.get(`${this.baseUrl}`)
  }
}
