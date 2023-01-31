import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GenreType } from '../models/genre.model';

@Injectable({
  providedIn: 'root'
})
export class GenresService {
  constructor(private httpClient: HttpClient) {}

  getAllGenres(): Observable<GenreType[]> {
    return this.httpClient.get<GenreType[]>('api/Genres');
  }

  postGenre(genre: GenreType): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.post(`api/Genres`, genre, { headers: headers })
  }

  putGenre(genre: GenreType, id: number): Observable<GenreType> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.put<GenreType>(`api/Genres/${id}`, genre, { headers: headers });
  }

  deleteGenre(id: number): Observable<{}> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.delete<GenreType>(`api/Genres/${id}`, { headers: headers });
  }
}
