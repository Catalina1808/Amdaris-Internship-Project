import { Component, OnInit } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { BooksService } from 'src/app/services/books.service';
import { ShelvesService } from 'src/app/services/shelves.service';
import { ActivatedRoute } from '@angular/router';
import { AddReviewDialogComponent } from '../dialogs/add-review-dialog/add-review-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ReviewType } from 'src/app/models/review.model';
import { ReviewsService } from 'src/app/services/reviews.service';
import { UserType } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/users.service';
import { map, Observable } from 'rxjs';

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
    genres: [],
    image: '',
    description: '',
    reviews: []
  }
  users: UserType[] = [];
  shelves: ShelfType[] = [];
  currentRate: number = 0;
  reviewId: number = 0;
  userId: string = "";

  constructor(private booksService: BooksService, private shelvesService: ShelvesService,
    private activatedRoute: ActivatedRoute, public dialog: MatDialog,
    private reviewsService: ReviewsService, public usersService: UsersService) { }

  ngOnInit(): void {
    this.getInfoFromToken();
    const bookId = this.activatedRoute.snapshot.paramMap.get("id");
    if (bookId != null) {
      this.booksService.getBookById(+bookId).subscribe(x => {
        this.book = x;
        this.currentRate = this.getBookRating(this.book);
        this.getUsers();
      });
    }
    this.refreshShelves();
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

  refreshBook(): void {
    const bookId = this.activatedRoute.snapshot.paramMap.get("id");
    if (bookId != null) {
      this.booksService.getBookById(+bookId).subscribe(x => {
        this.book = x;
        this.currentRate = this.getBookRating(this.book);
      });
    }
  }

  getUsers(): void {
    if (this.book.reviews) {
      this.book.reviews.forEach(review => {
        this.usersService.getUserById(review.userId).subscribe(x => this.users.push(x));
      });
    }
  }

  refreshShelves(): void {
    this.booksService.getUserShelves(this.userId).subscribe(x => this.shelves = x);
  }

  onShelfClick(shelf: ShelfType): void {
    if (this.verifyShelf(shelf)) {
      alert(`Book ${this.book.title} is already added to ${shelf.name} shelf!`);
    } else if (shelf.id !== undefined && this.book.id != null) {
      this.shelvesService.postBookToShelf(this.book.id, shelf.id).subscribe();
      alert(`Book ${this.book.title} added to ${shelf.name} shelf!`);
      this.refreshShelves();
    }
  }

  onAddedShelfClick(shelf: ShelfType): void {
    if (shelf.id !== undefined && this.book.id != null) {
      this.shelvesService.deleteBookFromShelf(this.book.id, shelf.id).subscribe();
      alert(`Book ${this.book.title} deleted from ${shelf.name} shelf!`);
      this.refreshShelves();
    }
  }

  verifyShelf(shelf: ShelfType): boolean {
    return shelf.books.some((b) => { return b.id == this.book.id })
  }

  alreadyAddedReview(element: ReviewType): boolean {
    if (element.bookId == this.book.id && element.userId == this.userId) {
      this.reviewId = element.id;
      return true;
    }
    return false;
  }

  changedRating(): void {
    if (this.book.reviews?.some((element) => this.alreadyAddedReview(element))) {
      const dialogRef = this.dialog.open(AddReviewDialogComponent, { data: { message: "Change your review" } });
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        if (result != null && this.book.id != null) {
          const review: ReviewType = { id: this.reviewId, rating: this.currentRate, comment: result, userId: this.userId, bookId: this.book.id, date: new Date() };
          this.reviewsService.putReview(review).subscribe(x => this.refreshBook());
          alert("Review updated!");
        }
      });
    } else {
      const dialogRef = this.dialog.open(AddReviewDialogComponent, { data: { message: "Add a review" } });
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        if (result != null && this.book.id != null) {
          const review: ReviewType = { id: 0, rating: this.currentRate, comment: result, userId: this.userId, bookId: this.book.id, date: new Date() };
          this.reviewsService.postReview(review).subscribe(x => this.refreshBook());
          alert("Review added!");
        }
      });
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

  getUserById(id: string): UserType{
    const user:UserType | undefined = this.users.find(user => user.id == id)
  
    return user || {id: "", userName: "", firstName: "", lastName: "", email: "", password:"", imagePath:""};
  }
}
