import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-information-request-all',
  templateUrl: './information-request-all.component.html',
  styleUrls: ['./information-request-all.component.scss']
})
export class InformationRequestAllComponent implements OnInit , AfterViewInit {
  Data: ICertificateLayout = {} as ICertificateLayout;

  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
  }
  ngAfterViewInit(): void {
    this.setSize()
    console.log(this.Data);
    
  }

  setSize(): void {
    const elements: NodeListOf<HTMLElement> = document.querySelectorAll('.size');
    elements.forEach(element => {
      const Height = element.offsetHeight; // Width of the element
      let fontSize = parseFloat(window.getComputedStyle(element).getPropertyValue('font-size')); // Initial font size in pixels      
      // Decrease font size until content fits within the width of the element
      while (element.scrollHeight > Height && fontSize > 0) {
        fontSize--;
        console.log(fontSize);
        
        element.style.fontSize = fontSize + 'px';
      }
    });
  }
}
