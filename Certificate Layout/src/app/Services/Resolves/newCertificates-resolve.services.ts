import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { CertificateServicesService } from '../certificate-services.service';

@Injectable({
  providedIn: 'root'
})
export class newCertificatesResolveServices implements Resolve<any> {

  constructor(private _CertificateServicesService : CertificateServicesService) { }

  resolve() : any
  {
    const formData: any = {
      pageIndex : 1,
      pageSize : 6
    };
    

    const observable = this._CertificateServicesService.getNewCertificates(formData)
    return observable
  }
}
