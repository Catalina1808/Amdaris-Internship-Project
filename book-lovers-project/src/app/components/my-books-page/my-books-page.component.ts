import { Component, OnInit, ViewChild } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-my-books-page',
  templateUrl: './my-books-page.component.html',
  styleUrls: ['./my-books-page.component.css'],
})
export class MyBooksPageComponent implements OnInit {
  books: BookType[] = [];

  constructor(private booksService: BooksService) { }

  ngOnInit(): void {
    this.booksService.getUserShelves(1).subscribe(x => {
    x.forEach(shelf => {
      shelf.books.forEach(book => {
        this.books.push(book);
      })});
    console.log(this.books);
    });
  }
}
