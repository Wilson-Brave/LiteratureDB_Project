import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { AdminComponent } from './Pages/admin/admin.component';
import { PublicComponent } from './Pages/public/public.component';
import { ManagerComponent } from './Pages/manager/manager.component';
import { LoginComponent } from './Modules/Auth/login/login.component';
import { RegisterComponent } from './Modules/Auth/register/register.component';
import { ConfirmEmailsComponent } from './Modules/Auth/confirm-emails/confirm-emails.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'confirmemail', component: ConfirmEmailsComponent },



  { path: '', component: HomeComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'manager', component: ManagerComponent },
  { path: 'public', component: PublicComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
