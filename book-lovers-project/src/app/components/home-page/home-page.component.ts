import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthorType } from 'src/app/models/author.model';
import { BookType } from 'src/app/models/book.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { BooksService } from 'src/app/services/books.service';
import { UsersService } from 'src/app/services/users.service';
import { BookCardComponent } from '../book-card/book-card.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  books: BookType[] = [];
  userId: string = "";
  author: AuthorType = { id: 0, name: "", image: "", description: "", books: [], followers: [] };

  @ViewChild("bookCard")
  bookCard: BookCardComponent | undefined;

  constructor(private usersService: UsersService, private authorsService: AuthorsService) { }

  ngOnInit(): void {
    this.getInfoFromToken();
    let authors: AuthorType[] = [];
    let randomIndex: number = 0;
    this.usersService.getUserById(this.userId).subscribe(user => {
      authors = user.authors;
      randomIndex = Math.floor(Math.random() * (authors.length - 1) + 1);
      this.author = authors[randomIndex - 1];
      if (this.author.books.length > 4)
        this.books = this.author.books.slice(-4);
      else
        this.books = this.author.books;
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

}
