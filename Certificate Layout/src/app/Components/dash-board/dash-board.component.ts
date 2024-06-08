import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginServicesService } from 'src/app/Services/login-services.service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.scss'],
})
export class DashBoardComponent implements OnInit{

  constructor(private _Router: Router,private _ActivatedRoute : ActivatedRoute , private _LoginServicesService : LoginServicesService) {}
  isRole :  string = "";
  isAdmin : boolean = false;
  isSideBarEnable : boolean = true;

  ngOnInit(): void {    
    this.isRole = this._LoginServicesService.decodeUserToken.getValue()["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    if (this.isRole == "Admin" ) 
    {
      this.isAdmin = true;
    }
    else 
    {
      this.isAdmin = false;
    }    
  } 
  
  toggleSideBar() : void 
  {
    this.isSideBarEnable = !this.isSideBarEnable;
    console.log(this.isSideBarEnable);
    
  }
  activeSubMenu: string | null = null;

  toggleSubMenu(subMenu: string) {
    if (this.activeSubMenu === subMenu) {
      this.activeSubMenu = null;
    } else {
      this.activeSubMenu = subMenu;
    }
  }


  logout() : void 
  {
    this._Router.navigate(['Login'])
  }




}
