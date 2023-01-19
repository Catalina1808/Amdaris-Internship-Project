import { P } from '@angular/cdk/keycodes';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserType } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(private httpClient: HttpClient) {}

  registerUser(user:UserType): Observable<{userId: string}> {
    return this.httpClient.post<{userId: string}>('api/Users/Register', user);
  }

  updateUser(user:UserType): Observable<{userId: string}> {
    return this.httpClient.put<{userId: string}>(`api/Users/${user.id}`, user);
  }

  loginUser(userName: string, password: string): Observable<{token: string}> {
    return this.httpClient.post<{token: string}>(`api/Users/Login?userName=${userName}&password=${password}`, {userName: userName, password: password});
  }

  assignRole(userId: string, role: string): Observable<any>{
    return this.httpClient.post(`api/Users/AssignRole?userId=${userId}&roleName=${role}`, {userId: userId, roleName: role}, {observe:'response', responseType:'text'});
  }

  deleteRole(userId: string, role: string): Observable<any>{
    return this.httpClient.delete(`api/Users/DeleteRole?userId=${userId}&roleName=${role}`, {observe:'response', responseType:'text'});
  }

  getUserById(userId:string): Observable<UserType> {
    return this.httpClient.get<UserType>(`api/Users/${userId}`);
  }
}
