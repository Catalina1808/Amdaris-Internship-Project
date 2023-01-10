import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthorType } from '../models/author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  constructor(private httpClient: HttpClient) {}

  postAuthor(author:AuthorType): Observable<AuthorType> {
    return this.httpClient.post<AuthorType>('api/Authors', author);
  }
}
