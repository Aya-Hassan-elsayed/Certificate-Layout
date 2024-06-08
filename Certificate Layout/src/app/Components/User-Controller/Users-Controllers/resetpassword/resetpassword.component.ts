import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginServicesService } from 'src/app/Services/login-services.service';
import { UserServicesService } from 'src/app/Services/user-services.service';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.scss']
})
export class ResetpasswordComponent {

  constructor(private location : Location,private _UserServicesService : UserServicesService , private  _LoginServicesService : LoginServicesService , private _Router : Router) {}
  isFormSubmittedSuccessfully: boolean = false;

  resetPasswordData :  FormGroup = new FormGroup({
    Password : new FormControl(null),
  })

  resetPassword (Data : FormGroup): void
  {


    const formJson =
    {
      Email : this._UserServicesService.userEmail,
      NewPassword : Data.get("Password")?.value,
      token : localStorage.getItem("userToken")
    }

  this._UserServicesService.resetPassword(formJson).subscribe(
      response =>
      {
        this.isFormSubmittedSuccessfully = true;
        setInterval(() => {
          this.isFormSubmittedSuccessfully = false;
        }, 3000);
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
