import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { CertificateServicesService } from '../certificate-services.service';

@Injectable({
  providedIn: 'root'
})
export class UntiTypeResolveService implements Resolve<any> {

  constructor(private _CertificateServicesService : CertificateServicesService) { }

  resolve() : any
  {
    const observable = this._CertificateServicesService.getUnitType()
    return observable
  }
}
