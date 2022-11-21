import { Component, OnInit } from '@angular/core';
import { NgProgress } from 'ngx-progressbar';
import { AuthService } from './../../../Modules/Auth/Resources/auth.service';
import { ProgressbarService } from './../../Services/progressbar.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})

export class HeaderComponent implements OnInit {

  constructor(
    private progress: NgProgress,
    public progressBar: ProgressbarService,
    private authService: AuthService

  ) {}

  ngOnInit(): void {
    this.progressBar.progressRef = this.progress.ref('progressBar');
  }

  isAdmin(): boolean {
    return this.authService.currentUser.role == 'Administrator' ? true : false;
  }

  isManager(): boolean {
    return this.authService.currentUser.role == 'Manager' ? true : false;
  }

}
