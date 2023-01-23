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
  pageNumber: number = 1;
  pageSize: number = 2;
  totalPages: number = 0;
  disablePrevButton = true;
  disableNextButton = false;

  constructor(private booksService: BooksService, private messageService: MessagesService) { }

  @ViewChild("bookCard")
  bookCard: BookCardComponent | undefined;

  ngOnInit(): void {
    this.getPage(this.pageNumber, this.pageSize);
    this.messageService.messageSubject.subscribe(x => alert(x));
  }

  getPage(pageNumber: number, pageSize: number) {
    this.booksService.getPagedBooks(pageNumber, pageSize).subscribe(x => {
      this.books = x.data;
      this.totalPages = x.totalPages;
      this.pageNumber = x.pageNumber;
      this.verifyPagingButtons();
    });
  }

  onPrevClick() {
    this.getPage(this.pageNumber - 1, this.pageSize);  
  }

  onNextClick() {
    this.getPage(this.pageNumber + 1, this.pageSize);
  }

  verifyPagingButtons() {
    console.log(this.pageNumber);
    if (this.pageNumber === 1)
      this.disablePrevButton = true;
    else
      this.disablePrevButton = false;

    if (this.pageNumber === this.totalPages)
      this.disableNextButton = true;
    else
      this.disableNextButton = false;
  }

  getBookRating(book: BookType): number {
    let averageRating: number = 0;
    book.reviews?.forEach(review => {
      averageRating += review.rating;
    });
    if (book.reviews == null || book.reviews.length == 0)
      return 0;
    return averageRating / book.reviews.length;
  }
}
