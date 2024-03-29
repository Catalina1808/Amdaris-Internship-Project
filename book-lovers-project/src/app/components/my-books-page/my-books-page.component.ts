import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { BooksService } from 'src/app/services/books.service';
import { ShelvesService } from 'src/app/services/shelves.service';
import { DialogAddShelfComponent } from '../dialogs/add-shelf-dialog/dialog-add-shelf.component';
import { DialogDeleteComponent } from '../dialogs/delete-dialog/dialog-delete.component';

@Component({
  selector: 'app-my-books-page',
  templateUrl: './my-books-page.component.html',
  styleUrls: ['./my-books-page.component.css'],
})
export class MyBooksPageComponent implements OnInit {
  books: BookType[] = [];
  displayedBooks: BookType[] = [];
  shelves: ShelfType[] = [];
  userId: string = "";

  constructor(private booksService: BooksService, public dialog: MatDialog,
    private shelvesService: ShelvesService) { }

  ngOnInit(): void {
    this.getInfoFromToken();
    this.booksService.getUserShelves(this.userId).subscribe(x => {
      this.shelves = x;
      this.shelves.forEach(shelf => {
        shelf.books.forEach(book => {
          this.books.push(book);
        })
      });
      this.displayedBooks = this.books;
    });
  }

  getInfoFromToken(): void {
    const token = localStorage.getItem('token');
    if (token) {
      let jwtData = token.split('.')[1]
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.parse(decodedJwtJsonData)

      this.userId = decodedJwtData.UserId;
    }
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

  onShelfClick(shelf: ShelfType): void {
    this.displayedBooks = shelf.books;
  }

  onDeleteShelfClick(shelf: ShelfType): void {
    const dialogRef = this.dialog.open(DialogDeleteComponent, { data: `${shelf.name} shelf` });
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed && shelf.id !== undefined) {
        this.shelvesService.deleteShelf(shelf.id).subscribe(x => this.refreshShelves())
      }
    });
  }

  refreshShelves(): void {
    this.booksService.getUserShelves(this.userId).subscribe(x => this.shelves = x);
  }

  addShelf(): void {
    const dialogRef = this.dialog.open(DialogAddShelfComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result != null) {
        const shelf: ShelfType = {name: result, userId: this.userId, books: [] };
        this.shelvesService.postShelf(shelf).subscribe(x => this.refreshShelves());
      }
    });
  }
}



