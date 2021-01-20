import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { User } from '../_models/user';
import { AlertService } from '../_services/alert.service';
import { ErrorService } from '../_services/error.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html'
})
export class AccountComponent {
  
  _userSelected: User = {};

  constructor(private userService: UserService, private app: AppComponent, private errorService: ErrorService, private alertService: AlertService) {
    this._userSelected = JSON.parse(localStorage.getItem(this.app.storageName));
  }

  save() {
    this.app.loading = true;
    this.userService.update(this._userSelected).subscribe(data => {
      localStorage.setItem(this.app.storageName, JSON.stringify(this._userSelected));
      this.alertService.showSucess("Your account has been updated.");
      this.app.loading = false;      
    }, err => {
        this.errorService.validateError(err);
        this.app.loading = false;
    });
  }
}


