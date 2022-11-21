import { AlertService } from '@full-fledged/alerts';
import { AuthService } from './../Resources/auth.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProgressbarService } from 'src/app/Shared/Services/progressbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private progressService: ProgressbarService,
    private alertService: AlertService
  ) {}

  ngOnInit(): void {}

  onSubmit(f: NgForm) {
    this.alertService.info('Check login information');
    this.progressService.startLoading();

    const loginObserver = {
      next: (x: any) => {
        this.progressService.setSuccess();
        this.alertService.success('Welcome back ' + x.username);
        this.progressService.completeLoading();
      },
      error: (err: any) => {
        this.progressService.setFailure();
        console.log(err);
        this.alertService.danger('Unable to Login');
        this.progressService.completeLoading();
      },
    };

    this.authService.login(f.value).subscribe(loginObserver);
  }
}
