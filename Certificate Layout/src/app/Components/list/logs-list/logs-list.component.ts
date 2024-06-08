import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ilogs } from 'src/app/Interfaces/ilogs';
import { LogServicesService } from 'src/app/Services/log-services.service';

@Component({
  selector: 'app-logs-list',
  templateUrl: './logs-list.component.html',
  styleUrls: ['./logs-list.component.scss']
})
export class LogsListComponent implements OnInit , AfterViewInit {
  constructor(private _ActivatedRoute : ActivatedRoute , private _LogServicesService : LogServicesService) {}
   data :  Ilogs[] = [];
  ngOnInit(): void {
    this.data = this._ActivatedRoute.snapshot.data["logsllis"];  
    this.sendLogs()
  }

  sendLogs() : void 
  {
    this._LogServicesService.addLog("open Logs List").subscribe()
  }
  ngAfterViewInit(): void {
    this.setSize()
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
  
}
