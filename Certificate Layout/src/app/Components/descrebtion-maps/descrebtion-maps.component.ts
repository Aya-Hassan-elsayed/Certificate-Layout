import { Component, OnInit } from '@angular/core';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-descrebtion-maps',
  templateUrl: './descrebtion-maps.component.html',
  styleUrls: ['./descrebtion-maps.component.scss']
})
export class DescrebtionMapsComponent implements OnInit {
  Data: ICertificateLayout = {} as ICertificateLayout;

  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
    console.log(this.Data.imageName !=null);
    
  }
}
