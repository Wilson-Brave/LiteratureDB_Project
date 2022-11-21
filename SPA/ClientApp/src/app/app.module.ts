import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './Shared/Components/footer/footer.component';
import { HeaderComponent } from './Shared/Components/header/header.component';

import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { AlertModule } from '@full-fledged/alerts';


import { NgProgressModule } from 'ngx-progressbar';
import { AuthButtonsComponent } from './Modules/Auth/auth-buttons/auth-buttons.component';
import { AuthLinksComponent } from './Modules/Auth/auth-links/auth-links.component';
import { ConfirmEmailsComponent } from './Modules/Auth/confirm-emails/confirm-emails.component';
import { LoginComponent } from './Modules/Auth/login/login.component';
import { RegisterComponent } from './Modules/Auth/register/register.component';
import { HomeComponent } from './Pages/home/home.component';
import { ManagerComponent } from './Pages/manager/manager.component';
import { PublicComponent } from './Pages/public/public.component';
import { AdminComponent } from './Pages/admin/admin.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    AuthButtonsComponent,
    AuthLinksComponent,
    LoginComponent,
    RegisterComponent,
    AuthLinksComponent,
    AuthButtonsComponent,
    ConfirmEmailsComponent,
    HomeComponent,
    ManagerComponent,
    PublicComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule,
    NgProgressModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    AlertModule.forRoot({maxMessages: 5, timeout: 5000,  positionX: "right"  })

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
