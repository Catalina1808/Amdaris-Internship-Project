import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShelfType } from '../models/shelf.model';

@Injectable({
  providedIn: 'root'
})
export class ShelvesService {
  constructor(private httpClient: HttpClient) {}

  postShelf(shelf: ShelfType): Observable<ShelfType> {
    return this.httpClient.post<ShelfType>('api/Shelves', shelf);
  }
}
