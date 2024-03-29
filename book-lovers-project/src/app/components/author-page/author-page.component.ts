import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { AuthorType } from 'src/app/models/author.model';
import { BookType } from 'src/app/models/book.model';
import { GenreType } from 'src/app/models/genre.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { BooksService } from 'src/app/services/books.service';
import { FileOperationsService } from 'src/app/services/file-operations.service';
import { DialogDeleteComponent } from '../dialogs/delete-dialog/dialog-delete.component';

@Component({
  selector: 'app-author-page',
  templateUrl: './author-page.component.html',
  styleUrls: ['./author-page.component.css']
})
export class AuthorPageComponent implements OnInit {
  author: AuthorType = { id: 1, name: "", books: [], image: "", description: "", followers: [] };
  genres: GenreType[] = [];
  allBooks: BookType[] = [];
  displayedBooks: BookType[] = [];
  userId: string = "";
  isAdmin: boolean = false;
  followButtonText = "Follow";


  constructor(private activatedRoute: ActivatedRoute, private authorService: AuthorsService, public dialog: MatDialog,
    private snackBar: MatSnackBar, private filesService: FileOperationsService, private booksService: BooksService) { }

  ngOnInit(): void {
    this.getInfoFromToken();
    const authorId = this.activatedRoute.snapshot.paramMap.get("id");
    if (authorId != null) {
      this.authorService.getAuthorById(+authorId).subscribe(x => {
        this.author = x;
        this.allBooks = this.author.books;
        this.displayedBooks = this.allBooks;
        this.getGenres();
        if (this.author.followers.some(item => item.id === this.userId))
          this.followButtonText = "Following";
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

  onFollowClick() {
    console.log(this.followButtonText);
    if (this.followButtonText === "Follow") {
      this.followButtonText = "Following";
      this.authorService.postFollowerToAuthor(this.userId, this.author.id).subscribe();
    }
    else {
      this.followButtonText = "Follow";
      this.authorService.deleteFollowerFromAuthor(this.userId, this.author.id).subscribe();
    }
  }

  onDeleteClick(): void {
    const dialogRef = this.dialog.open(DialogDeleteComponent, { data: `${this.author.name} author (the books written by this author will be deleted too)` });
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed && this.author.id !== undefined)
        this.deleteAuthorAndBooks();
      });
  }

  deleteAuthorAndBooks(): void {
    this.author.books.forEach(book => {
      if (book.id)
        this.booksService.deleteBook(book.id).subscribe(x => {
          const indexOfLastSlash = book.image.lastIndexOf('/');
          this.filesService.deletePhoto(book.image.substring(indexOfLastSlash + 1)).subscribe();
          this.deleteAuthor();
        });
    });
  }

  deleteAuthor():void{
    this.authorService.deleteAuthor(this.author.id).subscribe(x => {
      if (this.author.image != 'https://booklovers.blob.core.windows.net/photos/NoProfileImage.png') {
        const indexOfLastSlash = this.author.image.lastIndexOf('/');
        this.filesService.deletePhoto(this.author.image.substring(indexOfLastSlash + 1)).subscribe();
      }
      this.snackBar.open(`Author ${this.author.name} deleted!`, "Ok", {
        duration: 2000,
      })
    });
  }
}
