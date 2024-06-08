import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IUserDataForList } from "../../../../Interfaces/IUserDataForList";
import { UserServicesService } from 'src/app/Services/user-services.service';
import { LogServicesService } from 'src/app/Services/log-services.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  data: IUserDataForList[] = [];
  isSuccess : boolean = false;
  isFailed : boolean = false;
  isEnable : boolean = false;
  isDeleted : boolean = false;
  Message : string = "";

  constructor(public _Router : Router , private _ActivatedRoute : ActivatedRoute , private _UserServicesService : UserServicesService ,private _LogServicesService : LogServicesService) {}

ngOnInit(): void {
  this.data = this._ActivatedRoute.snapshot.data["us"];  
  this.sendLogs("open Users List")
}

sendLogs(note :  string) : void 
{
  this._LogServicesService.addLog(note).subscribe()
}
  ShowData(Id : string) :void
  {
    this._UserServicesService.userID = Id;
    this._Router.navigate(['DashBoard/UserInfo'])
  }
  changePassword(Id : string) :void
  {
    this._UserServicesService.userID = Id;
    this._Router.navigate(['DashBoard/changePassword'])
  }

  OpenAlertEnsureDelete(Id : string) :void
  {
    this._UserServicesService.userID = Id;
    this.isDeleted = true;
  }

  addCertificates(Id : string) :void
  {
    this._UserServicesService.userID = Id;
    this._Router.navigate(['DashBoard/addCertficates'])
  }

  CloseAlertEnsureDelete() : void
  {
    this.isDeleted = false;
  }

  DeleteIteameSure() : void
  {
    this._UserServicesService.deleteUser().subscribe(
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

  addRole(id : string) : void
  {
    this._UserServicesService.userID = id;
    this._Router.navigate(['DashBoard/userRole'])
  }
  resetPassword(Email : string) : void
  {
    this._UserServicesService.userEmail = Email;
    this._Router.navigate(['DashBoard/resetPassword'])
  }
  getData(event : any | null) :  void
  {
    const CompanyName = event.target?.value;
    this._UserServicesService.getUsers(CompanyName).subscribe(
      response =>
      {
        if (response) {
          this.data = response;
        }
      },
      error =>
      {

      }
    )
  }
}
