import { Component, OnInit } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { BooksService } from 'src/app/services/books.service';
import { ShelvesService } from 'src/app/services/shelves.service';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ReviewType } from 'src/app/models/review.model';
import { ReviewsService } from 'src/app/services/reviews.service';
import { UserType } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/users.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogDeleteComponent } from '../dialogs/delete-dialog/dialog-delete.component';
import { FileOperationsService } from 'src/app/services/file-operations.service';
import { AddReviewWithRatingDialogComponent } from '../dialogs/add-review-with-rating-dialog/add-review-with-rating-dialog.component';
import { Observable, shareReplay } from 'rxjs';

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
  isAdmin: boolean = false;

  constructor(private booksService: BooksService, private shelvesService: ShelvesService,
    private activatedRoute: ActivatedRoute, public dialog: MatDialog, private snackBar: MatSnackBar,
    private reviewsService: ReviewsService, public usersService: UsersService, private filesService: FileOperationsService) { }

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
      if (decodedJwtData.role == "Admin")
        this.isAdmin = true;
    }
  }

  refreshBook(): void {
    const bookId = this.activatedRoute.snapshot.paramMap.get("id");
    if (bookId != null) {
      this.booksService.getBookById(+bookId).subscribe(x => {
        this.book = x;
        this.currentRate = this.getBookRating(this.book);
        this.getUsers();
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

  onAddReviewClick(): void {
    if (this.book.reviews?.some((element) => this.alreadyAddedReview(element))) {
      const dialogRef = this.dialog.open(AddReviewWithRatingDialogComponent, { data: { message: "Change your review", rate: 0 } });
      dialogRef.afterClosed().subscribe(result => {
        if (result != null && this.book.id != null) {
          const review: ReviewType = { id: this.reviewId, rating: result.rate, comment: result.comment, userId: this.userId, bookId: this.book.id, date: new Date() };
          this.reviewsService.putReview(review).subscribe(x => this.refreshBook());
          this.snackBar.open("Review updated!", "Ok", {
            duration: 2000,
          });
        }
      });
    } else {
      const dialogRef = this.dialog.open(AddReviewWithRatingDialogComponent, { data: { message: "Add a review", rate: 0 } });
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        if (result != null && this.book.id != null) {
          const review: ReviewType = { id: 0, rating: result.rate, comment: result.comment, userId: this.userId, bookId: this.book.id, date: new Date() };
          this.reviewsService.postReview(review).subscribe(x => this.refreshBook());
          this.snackBar.open("Review added!", "Ok", {
            duration: 2000,
          });
        }
      });
    }
  }

  onShelfClick(shelf: ShelfType): void {
    if (this.verifyShelf(shelf)) {
      this.snackBar.open(`Book ${this.book.title} is already added to ${shelf.name} shelf!`, "Ok", {
        duration: 2000,
      })
    } else if (shelf.id !== undefined && this.book.id != null) {
      this.shelvesService.postBookToShelf(this.book.id, shelf.id).subscribe(x => this.refreshShelves());
      this.snackBar.open(`Book ${this.book.title} added to ${shelf.name} shelf!`, "Ok", {
        duration: 2000,
      });
    }
  }

  onAddedShelfClick(shelf: ShelfType): void {
    if (shelf.id !== undefined && this.book.id != null) {
      this.shelvesService.deleteBookFromShelf(this.book.id, shelf.id).subscribe(x => this.refreshShelves());
      this.snackBar.open(`Book ${this.book.title} deleted from ${shelf.name} shelf!`, "Ok", {
        duration: 2000,
      });
    }
  }

  onDeleteClick(): void {
    const dialogRef = this.dialog.open(DialogDeleteComponent, { data: `${this.book.title} book` });
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed && this.book.id !== undefined) {
        this.booksService.deleteBook(this.book.id).subscribe(x => {
          const indexOfLastSlash = this.book.image.lastIndexOf('/');
          this.filesService.deletePhoto(this.book.image.substring(indexOfLastSlash + 1)).subscribe();
          this.snackBar.open(`Book ${this.book.title} deleted!`, "Ok", {
            duration: 2000,
          })
        });
      }
    });
  }

  onDeleteReviewClick(review: ReviewType): void {
    const dialogRef = this.dialog.open(DialogDeleteComponent, { data: `your review` });
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.reviewsService.deleteReview(review.id).subscribe(x => this.refreshBook());
        this.snackBar.open(`Your review was deleted!`, "Ok", {
          duration: 2000,
        })
      }
    });
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

  getBookRating(book: BookType): number {
    let averageRating: number = 0;
    book.reviews?.forEach(review => {
      averageRating += review.rating;
    });
    if (book.reviews == null || book.reviews.length == 0)
      return 0;
    return +(averageRating / book.reviews.length).toFixed(2);
  }

  getUserById(id: string): UserType {
    let user: UserType | undefined = this.users.find(user => user.id == id);

    return user || { id: "", userName: "", firstName: "", lastName: "", email: "", password: "", imagePath: "", authors: [] };
  }
}
