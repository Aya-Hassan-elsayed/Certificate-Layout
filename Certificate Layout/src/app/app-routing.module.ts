import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CertificateListComponent } from './Components/list/certificate-list/certificate-list.component';
import { LogsListComponent } from './Components/list/logs-list/logs-list.component';
import { CertificateBoxComponent } from './Components/certificate-box/certificate-box.component';
import { UsersListComponent } from './Components/User-Controller/Users-Controllers/users-list/users-list.component';
import { UsersResolverService } from './Services/Resolves/users-for-list-resolver.service';
import { RoleListComponent } from './Components/User-Controller/Role-Controller/role-list/role-list.component';
import { RoleResolveService } from './Services/Resolves/role-resolve.service';
import { UserRoleComponent } from './Components/User-Controller/Role-Controller/user-role/user-role.component';
import { AddRoleComponent } from './Components/User-Controller/Role-Controller/add-role/add-role.component';
import { ChangePasswordComponent } from './Components/User-Controller/Users-Controllers/change-password/change-password.component';
import { ResetpasswordComponent } from './Components/User-Controller/Users-Controllers/resetpassword/resetpassword.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { UserInfoComponent } from './Components/User-Controller/Users-Controllers/user-info/user-info.component';
import { UsersInfoResolverService } from './Services/Resolves/users-Info-resolver.service';
import { AddNewUserComponent } from './Components/User-Controller/Users-Controllers/add-new-user/add-new-user.component';
import { newCertificatesResolveServices } from './Services/Resolves/newCertificates-resolve.services';
import { LoginComponent } from './Components/User-Controller/login/login.component';
import { DashBoardComponent } from './Components/dash-board/dash-board.component';
import { LogsResolverService } from './Services/Resolves/logs-resolver.service';
import { CertificateEditListComponent } from './Components/list/certificate-Edit-list/certificate-list.component';
import { EditCertificatesResolveServices } from './Services/Resolves/EditCertificates-resolve.services';
import { CertifcateInformationResolverService } from './Services/Resolves/certifcate-information-resolver.service';
import { HomeComponent } from './Components/home/home.component';
import { UntiTypeResolveService } from './Services/Resolves/unti-type-resolve.service';


const routes: Routes = [
  { path: '', redirectTo: 'Login', pathMatch: 'full' },
  {
  path: 'certificateInformations',
  component: CertificateBoxComponent,
  resolve: { certificateInformations: CertifcateInformationResolverService },

  },

  {
  path: 'Login',
  component: LoginComponent,
  },
  {
  path: 'DashBoard',
  component: DashBoardComponent,
  children : [
    {
      path: 'UsersList',
      component: UsersListComponent,
      resolve: { us: UsersResolverService },
    },
    {
      path: 'RoleList',
      component: RoleListComponent,
      resolve: { roleListData: RoleResolveService },
    },
    {
      path: 'userRole',
      component: UserRoleComponent,
      resolve: { roleListData: RoleResolveService },
    },
    {
      path: 'addRole',
      component: AddRoleComponent,
    },
    {
      path: 'changePassword',
      component: ChangePasswordComponent,
    },
    {
      path: 'resetPassword',
      component: ResetpasswordComponent,
    },
    {
      path: 'UserInfo',
      component: UserInfoComponent,
      resolve: { UserInfo: UsersInfoResolverService },
    },
    {
      path: 'AddNewUser',
      component: AddNewUserComponent,
    },
    {
      path: 'Home',
      component: HomeComponent,
    },
    {
      path: 'certificateList',
      component: CertificateListComponent,
      resolve : {CertificatesList : newCertificatesResolveServices , UntiTypes : UntiTypeResolveService}
      },
      {
      path: 'certificateEditList',
      component: CertificateEditListComponent,
      resolve : {CertificatesEditList : EditCertificatesResolveServices, UntiTypes : UntiTypeResolveService}
      },
    
      {
      path: 'LogsList',
      component: LogsListComponent,
      resolve : {logsllis : LogsResolverService}
      },
  ]
},
{ path: '**', component: NotFoundComponent },
  
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
