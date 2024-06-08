import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginServicesService } from 'src/app/Services/login-services.service';
import { LoginDto } from "../../../Interfaces/LoginDto";
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  Error : boolean = false;
constructor(private _LoginServicesService : LoginServicesService , private _Router : Router) {

}
  loginForm : FormGroup = new FormGroup({
    Email : new FormControl(null , [Validators.required]),
    Password : new FormControl(null , [Validators.required])
  })

  submitForm(Data : FormGroup): void {
    if (Data.valid) {
      const loginData: LoginDto = {
        email: Data.get('Email')?.value,
        Password: Data.get('Password')?.value,
      };

      this._LoginServicesService.tryLogin(loginData).subscribe(
        (response) => {
          if (response.status == 200)
          {
            localStorage.setItem("userToken" , response.token);
            
            this._LoginServicesService.SaveToken();

            this._Router.navigate(['DashBoard/Home']);
          }
        },
        (error) => {
          if (error.error.statusCode != 200)
          {
            this.Error = true;
          }
        }
      );
    } else {
      // Handle form validation errors
    }
  }
}
