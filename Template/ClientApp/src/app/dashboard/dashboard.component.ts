import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { ModuleService } from '../_services/module.service';
import { Module } from '../_models/module';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  

  constructor() {
    
  }
}


