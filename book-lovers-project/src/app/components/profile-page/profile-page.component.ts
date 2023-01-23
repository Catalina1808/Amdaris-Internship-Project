import { Component, Input } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { ShelfType } from 'src/app/models/shelf.model';
import { UserType } from 'src/app/models/user.model';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent{
  @Input()
  user: UserType =  {id: "", userName: "", firstName: "", lastName: "", email: "", password:"", imagePath:"", authors:[]};

  @Input()
  shelves: ShelfType[] = [];

  @Input()
  isCurrentUser:boolean = false;

  displayedBooks: BookType[] = [];
  displayedShelfName: string = "";

  onShelfClick(shelf: ShelfType): void {
    this.displayedBooks = shelf.books;
    this.displayedShelfName = shelf.name;
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
