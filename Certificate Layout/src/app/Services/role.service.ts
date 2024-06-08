import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseUrlService } from './base-url.service';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  constructor(private _HttpClient: HttpClient , private _BaseUrlService : BaseUrlService) {}

  roleID : string = "";
  baseUrl: string = `${this._BaseUrlService.BasUrl}api/Role`;


  getRoles(): Observable<any> {
    return this._HttpClient.get(this.baseUrl);
  }

  addNewRole(RoleData: any): Observable<any> {
    return this._HttpClient.post(this.baseUrl , RoleData);
  }

  deleteRole() :Observable<any>
  {
    return this._HttpClient.delete(`${this.baseUrl}/${this.roleID}`);
  }
}
