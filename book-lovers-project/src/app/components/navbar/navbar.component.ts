import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Router } from '@angular/router';
import { map, Observable, startWith } from 'rxjs';
import { AuthorType } from 'src/app/models/author.model';
import { BookType } from 'src/app/models/book.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userName: string = "";
  userImage: string = "";
  isAdmin: boolean = false;
  token: string | null = null;
  allAuthors: AuthorType[] = [];
  allBooks: BookType[] = [];
  filteredAuthors: Observable<AuthorType[]> | undefined;
  filteredBooks: Observable<BookType[]> | undefined;
  myControl = new FormControl('');

  constructor(private router: Router, private authorsService: AuthorsService, private booksService: BooksService) { }

  ngOnInit(): void {
    this.authorsService.getAllAuthors().subscribe(authors => this.allAuthors = authors);
    this.booksService.getAllBooks().subscribe(books => this.allBooks = books);
    this.filteredAuthors = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this.filterAuthors(value || '')),
    );
    this.filteredBooks = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this.filterBooks(value || '')),
    );
  }

  private filterAuthors(value: string): AuthorType[] {
    const filterValue = value.toLowerCase();
    return this.allAuthors.filter(option => option.name.toLowerCase().includes(filterValue));
  }

  private filterBooks(value: string): BookType[] {
    const filterValue = value.toLowerCase();
    return this.allBooks.filter(option => option.title.toLowerCase().includes(filterValue));
  }

  getInfoFromToken(): boolean {
    this.token = localStorage.getItem('token');
    if (this.token) {
      let jwtData = this.token.split('.')[1]
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.parse(decodedJwtJsonData)

      if (decodedJwtData.role == "Admin") {
        this.isAdmin = true;
      } else {
        this.isAdmin = false;
      }

      this.userName = decodedJwtData.name;
      this.userImage = decodedJwtData.ImagePath;

      return true;
    }
    return false;
  }

  logOut(): void {
    localStorage.clear();
    this.router.navigateByUrl('all-books');
  }

  getOptionName(option: AuthorType | BookType): string {
    if ((<AuthorType>option).name)
      return (<AuthorType>option).name;
    else if ((<BookType>option).title)
      return (<BookType>option).title;
    else
      return ""
  }

  selectedOption(event: MatAutocompleteSelectedEvent): void {
    if ((<AuthorType>event.option.value).name)
      this.router.navigateByUrl(`author/${(<AuthorType>event.option.value).id}`).then(() => {
        window.location.reload();
      });
    else if ((<BookType>event.option.value).title)
      this.router.navigate([`book/`, (<BookType>event.option.value).id]).then(() => {
        window.location.reload();
      });
  }
}
