import { Component, OnInit } from '@angular/core';
import { IRoleInfo } from "src/app/Interfaces/IRoleInfo";
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserServicesService } from 'src/app/Services/user-services.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user-role',
  templateUrl: './user-role.component.html',
  styleUrls: ['./user-role.component.scss']
})

export class UserRoleComponent implements OnInit {
  data: IRoleInfo[] = [];

  constructor(private location : Location,private _ActivatedRoute : ActivatedRoute , private _UserServicesService : UserServicesService , private _Router : Router) {}

  ngOnInit(): void {
    this.data = this._ActivatedRoute.snapshot.data["roleListData"] || [];
  }


  newRoleData : FormGroup = new FormGroup({
    Name :  new FormControl(null,[Validators.required]),
  });

  addRoleForUser(newRoleData : FormGroup) : void
  {
    const roles: string[] = [];
    roles.push(newRoleData.get("Name")?.value);
    const Data =
    {
      id : this._UserServicesService.userID,
      roles :roles
    }

    this._UserServicesService.addRoleForUser(Data).subscribe(
      Response =>
      {
        this._Router.navigate(['DashBoard/UserList'])
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
