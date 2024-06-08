import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-information-for-owner-request',
  templateUrl: './information-for-owner-request.component.html',
  styleUrls: ['./information-for-owner-request.component.scss']
})
export class InformationForOwnerRequestComponent implements OnInit , AfterViewInit {
  Data: ICertificateLayout = {} as ICertificateLayout;

  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
  }

  ngAfterViewInit(): void {
    this.setSize();
  }

  setSize(): void {
    const elements: NodeListOf<HTMLElement> = document.querySelectorAll('.size');
    elements.forEach(element => {
      const Height = element.offsetHeight; // Width of the element
      let fontSize = parseFloat(window.getComputedStyle(element).getPropertyValue('font-size')); // Initial font size in pixels      
      // Decrease font size until content fits within the width of the element
      while (element.scrollHeight > Height && fontSize > 0) {
        fontSize--;
        element.style.fontSize = fontSize + 'px';
      }
    });
  }
  
}
