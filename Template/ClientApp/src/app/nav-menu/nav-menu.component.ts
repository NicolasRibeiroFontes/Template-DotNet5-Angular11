import { Component } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { AppComponent } from '../app.component';
import { Module } from '../_models/module';
import { ErrorService } from '../_services/error.service';
import { ModuleService } from '../_services/module.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  _modules: Module[] = [];
  _modulesDefault: Module[] = [
    { name: 'Home', url: '/', icon: 'home', sequence: 1, id: 1},
    { name: 'Login', url: '/login', icon: 'login', sequence: 2, id: 2},
  ];
  constructor(private moduleService: ModuleService, private router: Router,private errorService: ErrorService, private app: AppComponent) {
    
    // decide what to do when this event is triggered.
    router.events.subscribe(event => {
      if (event instanceof NavigationStart){
        if (localStorage.getItem(this.app.storageName)) {
          this.getModules();
        }else{
          var _privateModule = this._modulesDefault.find(mod => mod.url==event.url);
          if (!_privateModule)
            this.router.navigateByUrl('/');

          this._modules = this._modulesDefault;
        }
     }
      
    });
  }

  getModules() {
    this.moduleService.getModules().subscribe(data => {
      this._modules = data;
    }, err => {
      this.router.navigateByUrl("/");
      this.errorService.validateError(err);
      this._modules = this._modulesDefault;
    });
  }  

  isPrivate(){
    return !this._modulesDefault.find(mod => mod.url == window.location.pathname);
  }

  logout(){
    localStorage.removeItem(this.app.storageName);
    this.router.navigateByUrl("/");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
