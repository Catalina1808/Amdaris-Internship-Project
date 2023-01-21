import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthorType } from '../models/author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  constructor(private httpClient: HttpClient) {}

  postAuthor(author:AuthorType): Observable<AuthorType> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.post<AuthorType>('api/Authors', author, { headers: headers });
  }

  postFollowerToAuthor(userId: string, authorId: number): Observable<AuthorType> {
    return this.httpClient.post<AuthorType>(`api/Authors/${authorId}/Users/${userId}`, userId);
  }

  updateAuthor(author:AuthorType): Observable<AuthorType> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.put<AuthorType>(`api/Authors/${author.id}`, author, { headers: headers });
  } 

  deleteFollowerFromAuthor(userId: string, authorId: number): Observable<{}> {
    return this.httpClient.delete(`api/Authors/${authorId}/Users/${userId}`);
  }

  getAllAuthors(): Observable<AuthorType[]> {
    return this.httpClient.get<AuthorType[]>('api/Authors');
  }

  getAuthorById(authorId:number): Observable<AuthorType> {
    return this.httpClient.get<AuthorType>(`api/Authors/${authorId}`);
  }
}
