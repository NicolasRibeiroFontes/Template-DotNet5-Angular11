import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { ModuleService } from '../_services/module.service';
import { Module } from '../_models/module';
import { UserService } from '../_services/user.service';
import { User } from '../_models/user';
import { AppComponent } from '../app.component';
import { ErrorService } from '../_services/error.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent {
  
  view: string = 'list';
  _users: User[] = [];
  _userSelected: User = {};

  constructor(private userService: UserService,private app: AppComponent, private errorService: ErrorService) {
    this.getUsers();
  }

  getUsers(){
    this.app.loading = true;
    this.userService.getUsers().subscribe(data => {
      this._users = data;
      this.app.loading = false;
    }, err => {
      this.errorService.validateError(err);
      this.app.loading = false;
    })
  }

  openDetails(user){
    this._userSelected = user;
    this.view = 'form';
  }
}


