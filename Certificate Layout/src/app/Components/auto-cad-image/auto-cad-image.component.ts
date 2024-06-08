import { Component, OnInit } from '@angular/core';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-auto-cad-image',
  templateUrl: './auto-cad-image.component.html',
  styleUrls: ['./auto-cad-image.component.scss']
})
export class AutoCadImageComponent implements OnInit {
  Data: ICertificateLayout = {} as ICertificateLayout;

  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
  }
}
