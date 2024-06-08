import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseUrlService {

  host : string = document.location.hostname
  BasUrl : string = `http://${this.host}:5001/`
  constructor() { 
    console.log(this.host);
    
  }
}
