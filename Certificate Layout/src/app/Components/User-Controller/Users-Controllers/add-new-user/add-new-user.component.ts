import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { EmailValidator, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { LogServicesService } from 'src/app/Services/log-services.service';
import { LoginServicesService } from 'src/app/Services/login-services.service';

@Component({
  selector: 'app-add-new-user',
  templateUrl: './add-new-user.component.html',
  styleUrls: ['./add-new-user.component.scss']
})
export class AddNewUserComponent implements OnInit {

constructor(private location : Location,private _LoginServicesService : LoginServicesService , private _Router : Router , private _LogServicesService : LogServicesService) {}
  
  ngOnInit(): void {
    this.sendLogs("open add new  user")
  }
  
  sendLogs(note :  string) : void 
  {
    this._LogServicesService.addLog(note).subscribe()
  }

  newUserData : FormGroup = new FormGroup({
    DisplayName :  new FormControl(null,[Validators.required]),
    Email :  new FormControl(null,[Validators.required,Validators.email]),
    PhoneNumber :  new FormControl(null,[Validators.required]),
    Password :  new FormControl(null,[Validators.required,]),
    confirmPasswordControl : new FormControl(null, [Validators.required ])
  }
)

  passwordMatchingValidator(formGroup :any ) : any
  {
    const password = formGroup.get('password').value;
    const confirmPassword = formGroup.get('confirmPassword').value;
    if (password !== confirmPassword) {
      return { passwordsNotMatching: true };
    } else {
      return null;
    }
  };

  addNewUser(newUserData : FormGroup) : void
  {
    const Data =
    {
      DisplayName : newUserData.get("DisplayName")?.value,
      Email : newUserData.get("Email")?.value,
      PhoneNumber : newUserData.get("PhoneNumber")?.value,
      Password : newUserData.get("Password")?.value,
    }

    this._LoginServicesService.Register(Data).subscribe(
      (response) =>
      {
        this.sendLogs("add new user with name " + newUserData.get("DisplayName")?.value)
        this._Router.navigate(['/UsersList'])

      },
      (erorr) =>
      {

      }
    );
  }

  bakePage() : void 
  {
    this.location.back();
  }
}
