import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Module } from "../_models/module";
import { UserAuthenticated } from "../_models/userAuthenticated";
import { UserLogin } from "../_models/userLogin";

@Injectable()
export class UserService {

  private _module: string = "api/users";

  constructor(private http: HttpClient) { }

  authenticate(user: UserLogin): Observable<UserAuthenticated> {
    return this.http.post<UserAuthenticated>("/" + this._module + "/authenticate", user);
  }

  register(user: UserLogin): Observable<UserAuthenticated> {
    return this.http.post<UserAuthenticated>("/" + this._module, user);
  }
}
