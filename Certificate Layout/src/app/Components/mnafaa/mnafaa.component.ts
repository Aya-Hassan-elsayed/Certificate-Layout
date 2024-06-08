import { Component, OnInit } from '@angular/core';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-mnafaa',
  templateUrl: './mnafaa.component.html',
  styleUrls: ['./mnafaa.component.scss']
})
export class MnafaaComponent implements OnInit {
  Data: ICertificateLayout = {} as ICertificateLayout;
  manwar : any 
  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
   this.manwar =  this.Data.totalArea == null ? 0 : this.Data.totalArea;
  }
}
