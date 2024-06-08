import { Component, OnInit } from '@angular/core';
import { IUserInfo } from "src/app/Interfaces/IUserInfo";
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit{
  data : IUserInfo  = {} as IUserInfo;

  constructor( private _ActivatedRoute : ActivatedRoute , private location : Location) {}

  ngOnInit(): void {
    this.data = this._ActivatedRoute.snapshot.data["UserInfo"] || {};
  }

  bakePage() : void
  {
    this.location.back();
  }
}
