import { Injectable } from '@angular/core';
import { LogServicesService } from '../log-services.service';

@Injectable({
  providedIn: 'root'
})
export class LogsResolverService {

  constructor(private _LogServicesService : LogServicesService) { }

  resolve() : any
  {
    const observable = this._LogServicesService.getLogs();
    return observable
  }
}
