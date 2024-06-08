import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-descreption-ard',
  templateUrl: './descreption-ard.component.html',
  styleUrls: ['./descreption-ard.component.scss']
})
export class DescreptionArdComponent implements OnInit , AfterViewInit{
  Data: ICertificateLayout = {} as ICertificateLayout;

  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
  }
  ngAfterViewInit(): void {
    this.setSize();
  }


  setSize(): void {
    const elements: NodeListOf<HTMLTableCellElement> = document.querySelectorAll('span.size');
    elements.forEach(element => {
        const maxHeight = 27; // Maximum height of the td element in millimeters
        let fontSize = parseFloat(window.getComputedStyle(element).getPropertyValue('font-size')); // Initial font size in pixels
        let contentHeight = element.scrollHeight; // Height of the content within the td element
        
        // Decrease font size until content fits within the maximum height of the td element
        while (contentHeight > maxHeight && fontSize > 9) {
            fontSize--;
            element.style.fontSize = fontSize + 'px';
           contentHeight = element.scrollHeight; // Height of the content within the td element
  
        }
    });
  }  
}
