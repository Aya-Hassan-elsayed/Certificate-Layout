import { Injectable } from '@angular/core';
import { CertificateServicesService } from '../certificate-services.service';
import { Resolve } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class CertifcateInformationResolverService implements Resolve<any> {

  constructor(private _CertificateServicesService : CertificateServicesService) { }

  resolve() : any
  {
    const observable = this._CertificateServicesService.getCertificateInformation()
    return observable
  }
}
