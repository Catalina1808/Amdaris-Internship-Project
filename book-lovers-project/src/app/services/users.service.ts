import { P } from '@angular/cdk/keycodes';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedUsersResponse, UserType } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(private httpClient: HttpClient) { }

  registerUser(user: UserType): Observable<{ userId: string }> {
    return this.httpClient.post<{ userId: string }>('api/Users/Register', user);
  }

  updateUser(user: UserType): Observable<{ userId: string }> {
    return this.httpClient.put<{ userId: string }>(`api/Users/${user.id}`, user);
  }

  loginUser(userName: string, password: string): Observable<{ token: string }> {
    return this.httpClient.post<{ token: string }>(`api/Users/Login?userName=${userName}&password=${password}`, { userName: userName, password: password });
  }

  assignRole(userId: string, role: string): Observable<any> {
    return this.httpClient.post(`api/Users/AssignRole?userId=${userId}&roleName=${role}`, { userId: userId, roleName: role }, { observe: 'response', responseType: 'text' });
  }

  deleteRole(userId: string, role: string): Observable<any> {
    return this.httpClient.delete(`api/Users/DeleteRole?userId=${userId}&roleName=${role}`, { observe: 'response', responseType: 'text' });
  }

  getUserById(userId: string): Observable<UserType> {
    return this.httpClient.get<UserType>(`api/Users/${userId}`);
  }

  getAllUsers(pageNumber: number, pageSize: number): Observable<PagedUsersResponse> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.get<PagedUsersResponse>(`api/Users?PageNumber=${pageNumber}&PageSize=${pageSize}`, { headers: headers });
  }

  getUserRoles(userId: string):  Observable<string[]>{
    return this.httpClient.get<string[]>(`api/Users/${userId}/Roles`);
  }

  deleteUser(id: string): Observable<{}> {
    return this.httpClient.delete<UserType>(`api/Users/${id}`);
  }
}
