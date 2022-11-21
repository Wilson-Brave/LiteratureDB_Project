import { Component, OnInit } from '@angular/core';
import { ProgressbarService } from './../../../Shared/Services/progressbar.service';
import { AlertService } from '@full-fledged/alerts';
import { AuthService } from '../Resources/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})

export class RegisterComponent implements OnInit {

  roleOptions: string[] = ['Administrator', 'Manager'];
  developerType: string[] = ['Developer', 'Designer'];

  model: any = {
    username: null,
    email: null,
    password: null,
    role: 'Administrator',
    jobtitle: 'Developer',
    //claim: 'Developer',
  };
  constructor(
    private progressService: ProgressbarService,
    private alertService: AlertService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {}

  onSubmit() {
    this.alertService.info('Creating new user');
    this.progressService.startLoading();

    const registerObserver = {
      next: (x: any) => {
        this.progressService.setSuccess();
        this.alertService.success('Account Created');
        this.progressService.completeLoading();
      },
      error: (err:any) => {
        this.progressService.setFailure();
        this.alertService.danger(err.error.errors[0].description);
        this.progressService.completeLoading();
      },
    };

    this.authService.register(this.model).subscribe(registerObserver);
  }

  roleChange(value: any) {
    this.model.role = value;
  }

  claimChange(value: any) {
    this.model.claim = value;
  }
}
