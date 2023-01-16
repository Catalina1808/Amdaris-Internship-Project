import { Component, OnInit, ViewChild } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { BooksService } from 'src/app/services/books.service';
import { MessagesService } from 'src/app/services/messages.service';
import { BookCardComponent } from '../book-card/book-card.component';

@Component({
  selector: 'app-all-books-page',
  templateUrl: './all-books-page.component.html',
  styleUrls: ['./all-books-page.component.css']
})
export class AllBooksPageComponent implements OnInit {
  books: BookType[] = []

  constructor(private booksService: BooksService, private messageService: MessagesService) { }

  @ViewChild("bookCard")
  bookCard: BookCardComponent | undefined;

  ngOnInit(): void {
    this.booksService.getAllBooks().subscribe(x => this.books = x);
    this.messageService.messageSubject.subscribe(x => alert(x));
  }

  getBookRating(book: BookType): number {
    var averageRating: number = 0;
    book.reviews?.forEach(review => {
      averageRating += review.rating;
    });
    if (book.reviews == null ||book.reviews.length == 0)
      return 0;
    return averageRating / book.reviews.length;
  }
}
