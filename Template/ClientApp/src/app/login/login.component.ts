import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';
import { UserChangePassword } from '../_models/userChangePassword';
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
  userChangePassword: UserChangePassword = {};

  constructor(private userService: UserService, private alertService: AlertService, private errorService: ErrorService, private app: AppComponent,
    private router: Router) { }

  authenticate() {
    this.app.loading = true;
    this.userService.authenticate(this.user).subscribe(data => {
      localStorage.setItem(this.app.storageName, JSON.stringify(data));
      this.router.navigateByUrl("/dashboard");
      this.app.loading = false;
    }, err => {
        this.errorService.validateError(err);
        this.app.loading = false;
    });
  }

  register() {    
    this.app.loading = true;
    this.userService.register(this.user).subscribe(data => {
      this.alertService.showSucess("Your account has been created. Please activate by the e-mail we just sent you");      
      this.app.loading = false;
    }, err => {
      this.errorService.validateError(err);
      this.app.loading = false;
    });
  }

  sendCode(){
    this.app.loading = true;
    this.userService.forgotPassword(this.user.email).subscribe(data => {
      this.alertService.showSucess("We just sent you an e-mail with a code.");      
      this.userChangePassword.email = this.user.email;
      this.view = 'changePassword';
      this.app.loading = false;
    }, err => {
        this.errorService.validateError(err);
        this.app.loading = false;
    });
  }

  changePassword(){
    this.app.loading = true;
    this.userService.changePassword(this.userChangePassword).subscribe(data => {
      this.alertService.showSucess("Your password has been changes successfully");      
      this.view = 'login';
      this.app.loading = false;
    }, err => {
        this.errorService.validateError(err);
        this.app.loading = false;
    });
  }
}
