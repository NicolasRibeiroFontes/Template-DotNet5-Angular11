import { Component } from '@angular/core';
import { Module } from '../_models/module';
import { ModuleService } from '../_services/module.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  _modules: Module[] = [];

  constructor(private moduleService: ModuleService) {

  }

  getModules() {
    this.moduleService.getModules().subscribe(data => {
      this._modules = data;
    }, err => {
        alert("Error Get Modules");
    });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
