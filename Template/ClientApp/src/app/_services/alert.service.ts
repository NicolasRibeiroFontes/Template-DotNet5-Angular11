import { Injectable } from "@angular/core";
import { ToastrService } from "ngx-toastr";

@Injectable()
export class AlertService {

  constructor(private toastr: ToastrService) { }

  showSucess(message){
    this.toastr.success(message);
  }

  showError(message){
    this.toastr.error(message);
  }
}
