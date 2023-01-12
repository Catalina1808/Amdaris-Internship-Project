import { Component, OnInit } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { BooksService } from 'src/app/services/books.service';
import { ShelvesService } from 'src/app/services/shelves.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-page',
  templateUrl: './book-page.component.html',
  styleUrls: ['./book-page.component.css']
})
export class BookPageComponent implements OnInit {
  book: BookType = {
    id: 0,
    title: '',
    authors: [],
    image: '',
    description: '',
  }
  shelves: ShelfType[] = [];

  constructor(private booksService: BooksService, private shelvesService: ShelvesService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    var bookId = this.activatedRoute.snapshot.paramMap.get("id");
    if(bookId != null){
      this.booksService.getBookById(+bookId).subscribe(x => this.book = x);
    }
    this.refreshShelves();
  }

  refreshShelves(): void {
    this.booksService.getUserShelves(1).subscribe(x => this.shelves = x);
  }

  onShelfClick(shelf: ShelfType): void {
    this.shelvesService.postBookToShelf(this.book.id, shelf.id).subscribe();
    alert(`Book ${this.book.title} added to ${shelf.name} shelf!`);
    this.refreshShelves();
  }

  onAddedShelfClick(shelf: ShelfType): void {
    this.shelvesService.deleteBookFromShelf(this.book.id, shelf.id).subscribe();
    alert(`Book ${this.book.title} deleted from ${shelf.name} shelf!`);
    this.refreshShelves();
  }


  verifyShelf(shelf: ShelfType): boolean {
    return shelf.books.some((b) => {return b.id ===this.book.id})
  }
}
