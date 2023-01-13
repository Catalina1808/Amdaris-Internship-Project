import { HttpClient } from '@angular/common/http';
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
}
