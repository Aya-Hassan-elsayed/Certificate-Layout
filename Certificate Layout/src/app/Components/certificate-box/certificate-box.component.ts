import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';
import { LogServicesService } from 'src/app/Services/log-services.service';
import { LoginServicesService } from 'src/app/Services/login-services.service';
import html2canvas from 'html2canvas';
import domtoimage from 'dom-to-image';
import { Location } from '@angular/common';
import { BaseUrlService } from 'src/app/Services/base-url.service';

@Component({
  selector: 'app-certificate-box',
  templateUrl: './certificate-box.component.html',
  styleUrls: ['./certificate-box.component.scss']
})
export class CertificateBoxComponent implements OnInit  {

  Data: ICertificateLayout = {} as ICertificateLayout;
  isRole :  string = "";
  isPrintEditEnable : boolean = false
  isEditEnable : Boolean  =false;
  constructor(private BaseUrlService :BaseUrlService, private  location : Location,private _Router : Router ,private _ActivatedRoute : ActivatedRoute,private _CertificateServicesService : CertificateServicesService , private _LogServicesService : LogServicesService, private _LoginServicesService : LoginServicesService) {}

  
  ngOnInit(): void {
    this.Data = this._ActivatedRoute.snapshot.data["certificateInformations"];     
    this._CertificateServicesService.Data = this.Data;
    this.sendLogs("open Certificate with request Number is " + this.Data.requestnumber)
    this.isRole = this._LoginServicesService.decodeUserToken.getValue()["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    this.isEditEnable = this._CertificateServicesService.isEditEnable;
  }


  PrintEdit () : void 
  {
    this.isPrintEditEnable = true;
  }



  captureScreenshot2(): void {
    const targetElement = document.getElementById('OutherContainerCertificate');
    if (targetElement) {
      const options : any  = {
        backgroundColor: '#ffffff' // Specify the background color here
      };


      domtoimage.toPng(targetElement, options )
        .then((dataUrl: any) => {
          const base64Index = dataUrl.indexOf('base64,');
          if (base64Index !== -1) {
            const imgData = dataUrl.substring(base64Index + 7);
            try {
              this.saveAsImage2(imgData);
            } catch (error) {
              console.error('Error saving image:', error);
            }
          } else {
            throw new Error('Invalid base64 data');
          }
        })
        .catch((error: any) => {
          console.error('Error capturing screenshot:', error);
        });
    } else {
      console.error('Target element not found');
    }
  }

  saveAsImage2(imgData: string): void {
    try {
      // Convert base64 image data to a Blob object
      const byteCharacters = atob(imgData);
      const byteNumbers = new Array(byteCharacters.length);
      for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
      }
      const byteArray = new Uint8Array(byteNumbers);
      const blob = new Blob([byteArray], { type: 'image/png' });
  
      // Create a FormData object to send the image data
      const formData = new FormData();
      formData.append('image', blob, 'screenshot.png');
      formData.append('requestNumber', this.Data.requestnumber);
      formData.append('numberofcopies', this.Data.numberofcopies == null || this.Data.numberofcopies == 0 ? '0': this.Data.numberofcopies.toString());
      console.log(this.Data.numberofcopies);
      
      // Make a POST request to your endpoint
      fetch(`https://${this.BaseUrlService.BasUrl}/api/CertificateLayout/UploadImage`, {
        method: 'POST',
        body: formData
      })
        .then(response => {
          if (!response.ok) {
            throw new Error('Failed to upload image');
          }
          this.sendLogs("print Certificate with request Number is " + this.Data.requestnumber);
          this.location.back();
        })
        .catch(error => {
          console.error('Error uploading image:', error);
        });
    } catch (error) {
      console.error('Error processing image data:', error);
    }
  }
  
  


sendLogs(note : string) : void 
{
  this._LogServicesService.addLog(note).subscribe()    
}
bakePage() : void 
{
  this.location.back();
}


}