import { Component, OnInit, ViewChild } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { GenreType } from 'src/app/models/genre.model';
import { BooksService } from 'src/app/services/books.service';
import { GenresService } from 'src/app/services/genres.service';
import { MessagesService } from 'src/app/services/messages.service';
import { BookCardComponent } from '../book-card/book-card.component';

@Component({
  selector: 'app-all-books-page',
  templateUrl: './all-books-page.component.html',
  styleUrls: ['./all-books-page.component.css']
})
export class AllBooksPageComponent implements OnInit {
  books: BookType[] = []
  genres: GenreType[] = []
  pageNumber: number = 1;
  pageSize: number = 3;
  totalPages: number = 0;
  disablePrevButton = true;
  disableNextButton = false;
  genreId: number = 0;

  constructor(private booksService: BooksService, private genresService: GenresService) { }

  @ViewChild("bookCard")
  bookCard: BookCardComponent | undefined;

  ngOnInit(): void {
    this.getPage(this.pageNumber, this.pageSize);
    this.genresService.getAllGenres().subscribe(genres => this.genres = genres);
  }


  onGenreClick(genre: GenreType) {
    this.genreId = genre.id;
    this.getGenrePage(1, this.pageSize);
  }

  onAllGenresClick() {
    this.genreId = 0;
    this.getPage(1, this.pageSize);
  }

  getPage(pageNumber: number, pageSize: number) {
    this.booksService.getPagedBooks(pageNumber, pageSize).subscribe(x => {
      this.books = x.data;
      this.totalPages = x.totalPages;
      this.pageNumber = x.pageNumber;
      this.verifyPagingButtons();
    });
  }

  getGenrePage(pageNumber: number, pageSize: number) {
    this.booksService.getPagedBooksByGenre(pageNumber, pageSize, this.genreId).subscribe(x => {
      this.books = x.data;
      this.totalPages = x.totalPages;
      this.pageNumber = x.pageNumber;
      this.verifyPagingButtons();
    });
  }

  onPrevClick() {
    if (this.genreId == 0)
      this.getPage(this.pageNumber - 1, this.pageSize);
    else
      this.getGenrePage(this.pageNumber - 1, this.pageSize);
  }

  onNextClick() {
    if (this.genreId == 0)
      this.getPage(this.pageNumber + 1, this.pageSize);
    else
      this.getGenrePage(this.pageNumber + 1, this.pageSize);
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
