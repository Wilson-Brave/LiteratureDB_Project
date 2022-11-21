import { AuthService } from './../Resources/auth.service';
import { Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-auth-buttons',
  templateUrl: './auth-buttons.component.html',
  styleUrls: ['./auth-buttons.component.scss'],
})
export class AuthButtonsComponent implements OnInit {
  constructor(public authService: AuthService) {}

  ngOnInit(): void {}

  logout() {
    console.log('working');
    this.authService.logout();
  }
}
