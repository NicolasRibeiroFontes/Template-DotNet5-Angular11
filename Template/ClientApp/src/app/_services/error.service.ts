import { Injectable } from "@angular/core";
import { AlertService } from "./alert.service";

@Injectable()
export class ErrorService {

  constructor(private alertService: AlertService) { }

  validateError(error) {
    switch (error.status) {
      case 400: {
        if (error.error.errors) {
          Object.keys(error.error.errors).forEach(item => {
            this.alertService.showError(error.error.errors[item]);
          })
        } else if (error.error.statusCode) {
          this.alertService.showError(error.error.message);
        }
        break;
      }
      case 401: {
        if (error.error.statusCode) {
          this.alertService.showError(error.error.message);
        } else
        this.alertService.showError(error.statusText);
        break;
      }   
      case 404: {
        if (error.error.statusCode) {
          this.alertService.showError(error.error.message);
        } else
        this.alertService.showError(error.statusText);
        break;
      }      
      case 409: {
        if (error.error.statusCode) {
          this.alertService.showError(error.error.message);
        } else
        this.alertService.showError(error.error.statusText);
        break;
      }
      default: {
        this.alertService.showError(error.error.statusText);
        break;
      }
    }
  }
}
