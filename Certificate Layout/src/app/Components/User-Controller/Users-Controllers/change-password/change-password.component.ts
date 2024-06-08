import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LogServicesService } from 'src/app/Services/log-services.service';
import { LoginServicesService } from 'src/app/Services/login-services.service';
import { UserServicesService } from 'src/app/Services/user-services.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  isFormSubmittedSuccessfully: boolean = false;

  constructor(private location : Location,private _UserServicesService : UserServicesService, private _Router : Router , private _LogServicesService : LogServicesService , private _LoginServicesService : LoginServicesService) {}
  changePassordData! : FormGroup;

ngOnInit(): void {
  const id = this._UserServicesService.userID;
  this.changePassordData = new  FormGroup({
    userid : new FormControl(id),
    CurrentPassword : new FormControl(null),
    NewPassword : new FormControl(null),
  });
  this.sendLogs("open change password for user" + this._LoginServicesService.decodeUserToken.getValue()["http://schemas.microsoft.com/ws/2008/06/identity/claims/Name"])
}

  sendLogs(note :  string) : void 
  {
    this._LogServicesService.addLog(note).subscribe()
  }

  changePassword(changePassordData : FormGroup) : void
  {
    const data = {
      userId : changePassordData.get("userid")?.value,
      CurrentPassword : changePassordData.get("CurrentPassword")?.value,
      NewPassword : changePassordData.get("NewPassword")?.value
    }

    this._UserServicesService.changePassword(data).subscribe(
      response =>
      {
          this.isFormSubmittedSuccessfully = true;
          setInterval(()=>{
            this.isFormSubmittedSuccessfully = false;
          },3000)
          this.sendLogs("Suucsuflly change password for user" + this._LoginServicesService.decodeUserToken.getValue()["http://schemas.microsoft.com/ws/2008/06/identity/claims/Name"])
          this._Router.navigate(['/UsersList'])
      },
      error =>
      {
        console.log(error);
      }
    )
  }
  bakePage() : void 
  {
    this.location.back();
  }
}
