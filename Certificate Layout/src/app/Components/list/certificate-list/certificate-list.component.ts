import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPageInfo } from 'src/app/Interfaces/Ipageinfo';
import { ICertifcateList } from 'src/app/Interfaces/icertifcate-list';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';
import { LogServicesService } from 'src/app/Services/log-services.service';
import * as L from 'leaflet';
import { IUntyType } from 'src/app/Interfaces/iunty-type';

@Component({
  selector: 'app-certificate-list',
  templateUrl: './certificate-list.component.html',
  styleUrls: ['./certificate-list.component.scss']
})
export class CertificateListComponent implements OnInit , AfterViewInit {
  Data : ICertifcateList[]  = [];
  pageInfo : IPageInfo = {} as IPageInfo;
  UntiType : IUntyType[] = [];
  isNotFoundedEnable : boolean  = false;
  constructor(private _Router : Router,private _ActivatedRoute : ActivatedRoute,private _LogServicesService : LogServicesService , private _CertificateServicesService : CertificateServicesService) {}
  
  ngOnInit(): void {    
    this.Data = this._ActivatedRoute.snapshot.data["CertificatesList"].certificateList;  
    this.pageInfo = this._ActivatedRoute.snapshot.data["CertificatesList"].pageInfo;    
    this.UntiType = this._ActivatedRoute.snapshot.data["UntiTypes"];
    this._CertificateServicesService.isEditEnable = false;

    this.sendLogs() ;

  }
  sendLogs() : void 
  {
    this._LogServicesService.addLog("open new Certificate List").subscribe()
  }

  setCertificateRequestNumber (requestNumber : string) : void 
  {
    this._CertificateServicesService.certificateRequestNumber = requestNumber;
    this._CertificateServicesService.type = false;
    this._Router.navigate(['certificateInformations'])
  }

  setPage(pageIndex :  number) : void
  {
    const Inputs : any = document.querySelectorAll('.input');    
    this.pageInfo.currentPage = pageIndex;
    const formData: any = {
      requestNumber : Inputs[0].value == '' ? null : Inputs[0].value , 
      name :  Inputs[1].value == '' ? null : Inputs[1].value ,
      uniteType : Inputs[2].value,
      surveyReview : Inputs[3].value,
      pageIndex : pageIndex,
      pageSize : 6
    };
    this._CertificateServicesService.getNewCertificates(formData).subscribe(
      res => 
      {
        this.Data = res.certificateList;  
        this.pageInfo = res.pageInfo;
      },
      err => 
      {
        console.log(err);
        
      }
    )
  }
  generatePageNumbers(): number[] {
    const totalPages = this.pageInfo.totalPages;
    const currentPage = this.pageInfo.currentPage;
    const pageCount = Math.min(totalPages - currentPage, 5) + 1;
    const pageNumbers: number[] = [];
  
    for (let i = currentPage; i < currentPage + pageCount; i++) {
      pageNumbers.push(i);
    }
  
    return pageNumbers;
  }

  ngAfterViewInit(): void {
    this.setSize();
    this.initializeMap();
  }

  setSize(): void {
    const elements: NodeListOf<HTMLElement> = document.querySelectorAll('.size');
  
    elements.forEach(element => {
      const width = element.offsetWidth; // Width of the element
      let fontSize = parseFloat(window.getComputedStyle(element).getPropertyValue('font-size')); // Initial font size in pixels
      
      // Decrease font size until content fits within the width of the element
      while (element.scrollWidth > width && fontSize > 0) {
        fontSize--;
        element.style.fontSize = fontSize + 'px';
      }
    });
  }
  
  isFilterListEnable : boolean = false;
  openFilterList () : void 
  {
    this.isFilterListEnable = !this.isFilterListEnable;    
  }

  removeFilter() : void 
  {
    const Inputs : any = document.querySelectorAll('.input');
    Inputs.forEach((e : any) =>
      {
        e.value = '';
      })
  }
  
  filterData() : void 
  {
    const Inputs : any = document.querySelectorAll('.input');    
    const formData: any = {
      requestNumber : Inputs[0].value == '' ? null : Inputs[0].value , 
      name :  Inputs[1].value == '' ? null : Inputs[1].value ,
      uniteType : Inputs[2].value,
      surveyReview : Inputs[3].value,
      pageIndex : 1,
      pageSize : 6
    };

    this._CertificateServicesService.getNewCertificates(formData).subscribe(
      res => 
      {

        this.Data = res.certificateList;  
        this.pageInfo = res.pageInfo;
        this.addGeoms()

        
      },
      err => 
      {
        if (err.error.statusCode == 404) {
          this.isNotFoundedEnable = true

          setTimeout(() => {
            this.isNotFoundedEnable = false
          }, 3000);
        } 
        console.log(err);
               
      }
    )  }

    map : any ;
    initializeMap(): void {
      // Create a Leaflet map centered at latitude 33.00 and longitude 20.5, with an initial zoom level of 10
      this.map = L.map('map').setView([30, 30.8025], 10);
    
      // Add a Google Maps tile layer with Arabic language
      L.tileLayer('http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}',{
        maxZoom: 20,
        subdomains:['mt0','mt1','mt2','mt3']
      }).addTo(this.map).bringToBack();

      this.addGeoms()
    }

    addGeoms () : void 
    { 
      var geoJsonLayer : any[] = [] ;
      
      let index : number = -1;
      this.Data.forEach((e : any ) => 
      {
        index = index + 1;

        var geoJsonData = JSON.parse(e.geom);
        geoJsonLayer[index] =  L.geoJSON(geoJsonData, {
          onEachFeature: function (feature, layer) {
              // Add custom behavior to each feature (if needed)
              
             layer.bindPopup("شهادة  رقم: " + e.requestnumber );

          },

       }).addTo(this.map)
      })
    }

    changeCertificateGrage() : void 
    {
      
      const select: any = document.querySelector('.GrageType');  
      const value =   select.value;

      if (value != 0) {
        this._CertificateServicesService.certificateGrageValue = value;
      }

    }
}
