import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { BookPostType, BookType } from '../models/book.model';
import { ShelfType } from '../models/shelf.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private httpClient: HttpClient) {}

  getAllBooks(): Observable<BookType[]> {
    return this.httpClient.get<BookType[]>('api/Books');
  }

  getUserShelves(userId:number): Observable<ShelfType[]> {
    return this.httpClient.get<ShelfType[]>(`api/Users/${userId}/Shelves`);
  }

  getBookById(bookId:number): Observable<BookType> {
    return this.httpClient.get<BookType>(`api/Books/${bookId}`);
  }

  postBook(book: BookPostType): Observable<BookType> {
    return this.httpClient.post<BookType>(`api/Books`, book);
  }
}
