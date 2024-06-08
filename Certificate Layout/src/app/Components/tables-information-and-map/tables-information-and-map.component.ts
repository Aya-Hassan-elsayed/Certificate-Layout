import { Component, OnInit } from '@angular/core';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-tables-information-and-map',
  templateUrl: './tables-information-and-map.component.html',
  styleUrls: ['./tables-information-and-map.component.scss']
})
export class TablesInformationAndMapComponent implements OnInit {
  Data: ICertificateLayout = {} as ICertificateLayout;

  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
  }
}
