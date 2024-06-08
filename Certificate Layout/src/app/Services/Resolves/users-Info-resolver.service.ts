import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { UserServicesService } from '../user-services.service';

@Injectable()
export class UsersInfoResolverService implements Resolve<any> {

  constructor(private _UserServicesService : UserServicesService) { }

  resolve() : any
  {
    const observable = this._UserServicesService.getUserData();
    // Return myData instead of observable
    return observable;
  }
}
