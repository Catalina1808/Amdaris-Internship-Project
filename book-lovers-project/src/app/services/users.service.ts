import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserType } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(private httpClient: HttpClient) {}

  postUser(user:UserType): Observable<UserType> {
    return this.httpClient.post<UserType>('api/Users', user);
  }

  getUserById(userId:number): Observable<UserType> {
    return this.httpClient.get<UserType>(`api/Users/${userId}`);
  }
}
