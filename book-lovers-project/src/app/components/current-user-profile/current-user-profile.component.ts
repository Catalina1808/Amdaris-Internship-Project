import { Component, OnInit } from '@angular/core';
import { ShelfType } from 'src/app/models/shelf.model';
import { UserType } from 'src/app/models/user.model';
import { BooksService } from 'src/app/services/books.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-current-user-profile',
  templateUrl: './current-user-profile.component.html',
  styleUrls: ['./current-user-profile.component.css']
})
export class CurrentUserProfileComponent implements OnInit {
  user: UserType = { id: "", userName: "", firstName: "", lastName: "", email: "", password: "", imagePath: "", authors:[] };

  shelves: ShelfType[] = [];
  constructor(private userService: UsersService, private booksService: BooksService) { }


  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      let jwtData = token.split('.')[1];
      let decodedJwtJsonData = window.atob(jwtData);
      let decodedJwtData = JSON.parse(decodedJwtJsonData);
      const userId = decodedJwtData.UserId;

      this.userService.getUserById(userId).subscribe(x => this.user = x);
      this.booksService.getUserShelves(userId).subscribe(x => this.shelves = x);
    }
  }
}
