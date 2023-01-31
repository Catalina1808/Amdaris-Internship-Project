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

  deleteShelf(id: number): Observable<{}> {
    return this.httpClient.delete<ShelfType>(`api/Shelves/${id}`);
  }

  postBookToShelf(idBook: number, idShelf: number): Observable<{}> {
    return this.httpClient.post<number>(`api/Shelves/${idShelf}/Books/${idBook}`, idBook);
  }

  deleteBookFromShelf(idBook: number, idShelf: number): Observable<{}> {
    return this.httpClient.delete<number>(`api/Shelves/${idShelf}/Books/${idBook}`);
  }
}
