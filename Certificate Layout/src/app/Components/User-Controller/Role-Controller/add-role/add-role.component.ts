import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LogServicesService } from 'src/app/Services/log-services.service';
import { RoleService } from 'src/app/Services/role.service';


@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
  styleUrls: ['./add-role.component.scss']
})
export class AddRoleComponent implements OnInit{

  constructor(private _RoleService : RoleService , private _Router : Router,private _LogServicesService : LogServicesService) {}

  newRoleData : FormGroup = new FormGroup({
    Name :  new FormControl(null,[Validators.required]),
  }
)
ngOnInit(): void {
  this.sendLogs("open add role ")
}

sendLogs(note : string) : void 
{
  this._LogServicesService.addLog(note).subscribe
  (
    response => 
    {
    },
    error => 
    {
    }
  )
}

  addNewRole(newRoleData : FormGroup) : void
  {
    const Data : any =
    {
      name : newRoleData.get("Name")?.value,
    }
    this._RoleService.addNewRole(Data).subscribe(
      (response) =>
      {
        this.sendLogs(`add new role ${ newRoleData.get("Name")?.value}`  );
        this._Router.navigate(['DashBoard/RoleList'])

      },
      (erorr) =>
      {

      }
    );
  }
}
