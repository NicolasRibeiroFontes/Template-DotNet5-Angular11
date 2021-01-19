import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Module } from "../_models/module";

@Injectable()
export class ModuleService {

  private _module: string = "/api/modules";

  constructor(private http: HttpClient) { }

  getModules(): Observable<Module[]> {
    return this.http.get<Module[]>("https://localhost:44340" + this._module);
  }
}
