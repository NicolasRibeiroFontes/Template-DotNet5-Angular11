import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Module } from "../_models/module";
import { User } from "../_models/user";
import { UserAuthenticated } from "../_models/userAuthenticated";
import { UserChangePassword } from "../_models/userChangePassword";
import { UserLogin } from "../_models/userLogin";

@Injectable()
export class UserService {

  private _module: string = "/api/users";

  constructor(private http: HttpClient) { }

  authenticate(user: UserLogin): Observable<UserAuthenticated> {
    return this.http.post<UserAuthenticated>("https://localhost:44340" + this._module + "/authenticate", user);
  }

  register(user: UserLogin): Observable<UserAuthenticated> {
    return this.http.post<UserAuthenticated>("https://localhost:44340" + this._module, user);
  }

  forgotPassword(email: string): Observable<boolean> {
    return this.http.get<boolean>("https://localhost:44340" + this._module + "/forgot-password/" + email);
  }

  changePassword(data: UserChangePassword): Observable<boolean> {
    return this.http.post<boolean>("https://localhost:44340" + this._module + "/change-password", data);
  }

  getUsers(): Observable<User[]>{
    return this.http.get<User[]>("https://localhost:44340" + this._module );
  }

  update(user: User): Observable<User> {    
    return this.http.put<User>("https://localhost:44340" + this._module, user);
  }
}
