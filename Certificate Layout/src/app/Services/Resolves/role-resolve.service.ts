import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { RoleService } from '../role.service';

@Injectable({
  providedIn: 'root'
})
export class RoleResolveService implements Resolve<any> {

  constructor(private _RoleService : RoleService) { }

  resolve() : any
  {
    const observable = this._RoleService.getRoles();
    return observable
  }
}
