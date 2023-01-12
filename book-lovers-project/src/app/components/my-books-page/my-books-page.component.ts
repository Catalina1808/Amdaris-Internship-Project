import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { BooksService } from 'src/app/services/books.service';
import { ShelvesService } from 'src/app/services/shelves.service';
import { DialogAddShelfComponent } from '../dialog-add-shelf/dialog-add-shelf.component';
import { DialogDeleteComponent } from '../dialog-delete/dialog-delete.component';

@Component({
  selector: 'app-my-books-page',
  templateUrl: './my-books-page.component.html',
  styleUrls: ['./my-books-page.component.css'],
})
export class MyBooksPageComponent implements OnInit {
  books: BookType[] = [];
  displayedBooks: BookType[] = [];
  shelves: ShelfType[] = [];

  constructor(private booksService: BooksService, public dialog: MatDialog,
    private shelvesService: ShelvesService) { }

  ngOnInit(): void {
    this.booksService.getUserShelves(1).subscribe(x => {
      this.shelves = x;
      this.shelves.forEach(shelf => {
        shelf.books.forEach(book => {
          this.books.push(book);
        })
      });
      this.displayedBooks = this.books;
    });
  }

  onShelfClick(shelf: ShelfType): void {
    this.displayedBooks = shelf.books;
  }

  onDeleteShelfClick(shelf: ShelfType): void {
    const dialogRef = this.dialog.open(DialogDeleteComponent, { data: `${shelf.name} shelf` });
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.shelvesService.deleteShelf(shelf.id).subscribe(x => this.refreshShelves())
      }
    });
  }

  refreshShelves(): void {
    this.booksService.getUserShelves(1).subscribe(x => this.shelves = x);
  }

  addShelf(): void {
    const dialogRef = this.dialog.open(DialogAddShelfComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result != null) {
        var shelf: ShelfType = { id: 0, name: result, userId: 1, books: [] };
        this.shelvesService.postShelf(shelf).subscribe(x => this.refreshShelves());
      }
    });
  }
}


