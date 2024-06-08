import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CertificateBoxComponent } from './Components/certificate-box/certificate-box.component';
import { HeaderBoxComponent } from './Components/header-box/header-box.component';
import { HeaderLogosComponent } from './Components/header-logos/header-logos.component';
import { HeaderAdresessComponent } from './Components/header-adresess/header-adresess.component';
import { TablesInformationAndMapComponent } from './Components/tables-information-and-map/tables-information-and-map.component';
import { InformationRequestAllComponent } from './Components/information-request-all/information-request-all.component';
import { InformationRequestComponent } from './Components/information-request/information-request.component';
import { InformationForOwnerRequestComponent } from './Components/information-for-owner-request/information-for-owner-request.component';
import { TableCordinatesComponent } from './Components/table-cordinates/table-cordinates.component';
import { TableEdgesComponent } from './Components/table-edges/table-edges.component';
import { MapLeafletComponent } from './Components/map-leaflet/map-leaflet.component';
import { CertificateInformationComponent } from './Components/certificate-information/certificate-information.component';
import { AutocadImageAndSomeDataComponent } from './Components/autocad-image-and-some-data/autocad-image-and-some-data.component';
import { AutoCadImageComponent } from './Components/auto-cad-image/auto-cad-image.component';
import { DescrebtionMapsComponent } from './Components/descrebtion-maps/descrebtion-maps.component';
import { InstructionsComponent } from './Components/instructions/instructions.component';
import { CertificateListComponent } from './Components/list/certificate-list/certificate-list.component';
import { LogsListComponent } from './Components/list/logs-list/logs-list.component';
import { DescreptionsComponent } from './Components/descreptions/descreptions.component';
import { ChangePasswordComponent } from './Components/User-Controller/Users-Controllers/change-password/change-password.component';
import { ResetpasswordComponent } from './Components/User-Controller/Users-Controllers/resetpassword/resetpassword.component';
import { UserInfoComponent } from './Components/User-Controller/Users-Controllers/user-info/user-info.component';
import { UsersListComponent } from './Components/User-Controller/Users-Controllers/users-list/users-list.component';
import { AddRoleComponent } from './Components/User-Controller/Role-Controller/add-role/add-role.component';
import { RoleListComponent } from './Components/User-Controller/Role-Controller/role-list/role-list.component';
import { UsersResolverService } from './Services/Resolves/users-for-list-resolver.service';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { UserRoleComponent } from './Components/User-Controller/Role-Controller/user-role/user-role.component';
import { UsersInfoResolverService } from './Services/Resolves/users-Info-resolver.service';
import { RoleResolveService } from './Services/Resolves/role-resolve.service';
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
import { MnafaaComponent } from './Components/mnafaa/mnafaa.component';
import { DescreptionArdComponent } from './Components/descreption-ard/descreption-ard.component';
import { DescreptionMabnaComponent } from './Components/descreption-mabna/descreption-mabna.component';
import { CertificateFoldersPathesComponent } from './Components/certificate-folders-pathes/certificate-folders-pathes.component';

@NgModule({
  declarations: [
    AppComponent,
    CertificateBoxComponent,
    HeaderBoxComponent,
    HeaderLogosComponent,
    HeaderAdresessComponent,
    TablesInformationAndMapComponent,
    InformationRequestAllComponent,
    InformationRequestComponent,
    InformationForOwnerRequestComponent,
    TableCordinatesComponent,
    TableEdgesComponent,
    MapLeafletComponent,
    CertificateInformationComponent,
    AutocadImageAndSomeDataComponent,
    AutoCadImageComponent,
    DescrebtionMapsComponent,
    InstructionsComponent,
    CertificateListComponent,
    LogsListComponent,
    DescreptionsComponent,
    ChangePasswordComponent,
    ResetpasswordComponent,
    UserInfoComponent,
    UsersListComponent,
    AddRoleComponent,
    RoleListComponent,
    NotFoundComponent,
    UserRoleComponent,
    AddNewUserComponent,
    LoginComponent,
    DashBoardComponent,
    CertificateEditListComponent,
    HomeComponent,
    MnafaaComponent,
    DescreptionArdComponent,
    DescreptionMabnaComponent,
    CertificateFoldersPathesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: 
  [
    UsersResolverService,
    UsersInfoResolverService,
    RoleResolveService,
    newCertificatesResolveServices,
    LogsResolverService,
    EditCertificatesResolveServices,
    CertifcateInformationResolverService,
    UntiTypeResolveService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
