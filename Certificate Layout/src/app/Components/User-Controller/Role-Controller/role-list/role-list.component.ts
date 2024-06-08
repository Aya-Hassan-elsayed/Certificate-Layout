import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RoleService } from 'src/app/Services/role.service';
import { IRoleInfo } from 'src/app/Interfaces/IRoleInfo';
import { LogServicesService } from 'src/app/Services/log-services.service';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {
  data: IRoleInfo[] = [];
  isSuccess : boolean = false;
  isFailed : boolean = false;
  isEnable : boolean = false;
  isDeleted : boolean = false;
  Message : string = "";

  constructor(public _Router : Router , private _ActivatedRoute : ActivatedRoute , private _RoleService : RoleService,private _LogServicesService : LogServicesService) {}

ngOnInit(): void {
  this.data = this._ActivatedRoute.snapshot.data["roleListData"] || [];
  this.sendLogs()
}
sendLogs() : void 
{
  this._LogServicesService.addLog("open Role List").subscribe()
}

  OpenAlertEnsureDelete(Id : string) :void
  {
    this._RoleService.roleID = Id;
    this.isDeleted = true;
  }

  EditeRole(Id : string) :void
  {
    this._RoleService.roleID = Id;
    this._Router.navigate(['DashBoard/addCertficates'])
  }

  CloseAlertEnsureDelete() : void
  {
    this.isDeleted = false;
  }

  DeleteIteameSure() : void
  {
    this._RoleService.deleteRole().subscribe(
      (response) => {

        if (response.statusCode == 200)
        {
          this.Message = response.message;
          this.isEnable = true;
          this.isSuccess = true;
          this.CloseAlertEnsureDelete();
          setTimeout(() => {
            this.isEnable = false;
            this.isSuccess = false;
          }, 3000);
        }
      },
      (error) => {
        this.Message = error.error.message;
        this.isEnable = true;
        this.isFailed = true;
        this.CloseAlertEnsureDelete();
        setTimeout(() => {
          this.isEnable = false;
          this.isFailed = false;
        }, 3000);
      }
    );
  }
}
