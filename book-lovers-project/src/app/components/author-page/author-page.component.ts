import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthorType } from 'src/app/models/author.model';
import { BookType } from 'src/app/models/book.model';
import { GenreType } from 'src/app/models/genre.model';
import { AuthorsService } from 'src/app/services/authors.service';

@Component({
  selector: 'app-author-page',
  templateUrl: './author-page.component.html',
  styleUrls: ['./author-page.component.css']
})
export class AuthorPageComponent implements OnInit {
  author: AuthorType = { id: 1, name: "", books: [], image: "", description: "" };
  genres: GenreType[] = [];
  allBooks: BookType[] = [];
  displayedBooks: BookType[] = [];
  userId: string = "";
  isAdmin: boolean = false;


  constructor(private activatedRoute: ActivatedRoute, private authorService: AuthorsService) { }

  ngOnInit(): void {
    this.getInfoFromToken();
    const authorId = this.activatedRoute.snapshot.paramMap.get("id");
    if (authorId != null) {
      this.authorService.getAuthorById(+authorId).subscribe(x => {
        this.author = x;
        this.allBooks = this.author.books;
        this.displayedBooks = this.allBooks;
        this.getGenres();
      });
    }
  }

  getGenres() {
    this.author.books.forEach(book => {
      book.genres.forEach(genre => {
        if (!this.genres.some(item => item.id === genre.id))
          this.genres.push(genre);
      });
    });
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

  getBookRating(book: BookType): number {
    let averageRating: number = 0;
    book.reviews?.forEach(review => {
      averageRating += review.rating;
    });
    if (book.reviews == null || book.reviews.length == 0)
      return 0;
    return averageRating / book.reviews.length;
  }

  onGenreClick(genre: GenreType) {
    this.displayedBooks = this.allBooks.filter(book => book.genres.some(item => item.id === genre.id) === true);
  }

  onAllGenresClick() {
    this.displayedBooks = this.allBooks;
  }
}
