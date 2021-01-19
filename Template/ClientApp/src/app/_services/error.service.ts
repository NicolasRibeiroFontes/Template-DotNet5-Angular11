import { Injectable } from "@angular/core";
import { AlertService } from "./alert.service";

@Injectable()
export class ErrorService {

  constructor(private alertService: AlertService) { }

  validateError(error){
      if (Array.isArray(error)){
          error.forEach(item => {
              this.alertService.showError(item);
          })
      }else if (error.status == 404){
        this.alertService.showError(error.statusText);
      }
  }
}
