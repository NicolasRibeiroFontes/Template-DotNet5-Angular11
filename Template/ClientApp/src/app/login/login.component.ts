import { Component } from '@angular/core';
import { UserLogin } from '../_models/userLogin';
import { AlertService } from '../_services/alert.service';
import { ErrorService } from '../_services/error.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  view: string = "login";
  user: UserLogin = {};

  constructor(private userService: UserService, private alertService: AlertService, private errorService: ErrorService) { }

  authenticate() {
    this.userService.authenticate(this.user).subscribe(data => {
      console.log(data);
    }, err => {
      debugger;
        this.errorService.validateError(err);
    });
  }

  register() {    
    this.userService.register(this.user).subscribe(data => {
      console.log(data);
    }, err => {
      console.log(err);
    });
  }
}
