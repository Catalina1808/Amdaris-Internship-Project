import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { BookPostType, BookType, PagedBooksResponse } from '../models/book.model';
import { ShelfType } from '../models/shelf.model';


@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private httpClient: HttpClient) { }

  getAllBooks(): Observable<BookType[]> {
    return this.httpClient.get<BookType[]>(`api/Books`);
  }

  getPagedBooks(pageNumber: number, pageSize: number): Observable<PagedBooksResponse> {
    return this.httpClient.get<PagedBooksResponse>(`api/Books/Paged?PageNumber=${pageNumber}&PageSize=${pageSize}`);
  }

  getPagedBooksByGenre(pageNumber: number, pageSize: number, genreId:number): Observable<PagedBooksResponse> {
    return this.httpClient.get<PagedBooksResponse>(`api/Books/PagedByGenre/${genreId}?PageNumber=${pageNumber}&PageSize=${pageSize}`);
  }

  getUserShelves(userId: string): Observable<ShelfType[]> {
    return this.httpClient.get<ShelfType[]>(`api/Users/${userId}/Shelves`);
  }

  getBookById(bookId: number): Observable<BookType> {
    return this.httpClient.get<BookType>(`api/Books/${bookId}`);
  }

  postBook(book: BookPostType): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.post(`api/Books`, book, { headers: headers })
  }

  putBook(book: BookPostType, id: number): Observable<BookType> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.put<BookType>(`api/Books/${id}`, book, { headers: headers });
  }

  deleteBook(id: number): Observable<{}> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.httpClient.delete<BookType>(`api/Books/${id}`, { headers: headers });
  }
}
