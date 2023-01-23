import { U } from '@angular/cdk/keycodes';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { UserType } from 'src/app/models/user.model';
import { BooksService } from 'src/app/services/books.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  isCurrentUser: boolean = false;
  userId: string = "";
  user: UserType = { id: "", userName: "", firstName: "", lastName: "", email: "", password: "", imagePath: "", authors: [] };
  shelves: ShelfType[] = [];

  constructor(private userService: UsersService, private booksService: BooksService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get("id");
    if (id)
      this.userId = id;
    this.getInfoFromToken();
    this.userService.getUserById(this.userId).subscribe(x => this.user = x);
    this.booksService.getUserShelves(this.userId).subscribe(x => this.shelves = x);

  }

  displayedBooks: BookType[] = [];
  displayedShelfName: string = "";

  onShelfClick(shelf: ShelfType): void {
    this.displayedBooks = shelf.books;
    this.displayedShelfName = shelf.name;
  }

  getInfoFromToken(): void {
    const token = localStorage.getItem('token');
    if (token) {
      let jwtData = token.split('.')[1]
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.parse(decodedJwtJsonData)
      if (this.userId === decodedJwtData.UserId)
        this.isCurrentUser = true;
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
}
