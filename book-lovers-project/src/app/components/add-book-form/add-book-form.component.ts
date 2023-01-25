import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import { map, Observable, startWith } from 'rxjs';
import { AuthorType } from 'src/app/models/author.model';
import { GenreType } from 'src/app/models/genre.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { GenresService } from 'src/app/services/genres.service';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { FileOperationsService } from 'src/app/services/file-operations.service';
import { BookPostType, BookType } from 'src/app/models/book.model';
import { BooksService } from 'src/app/services/books.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-book-form',
  templateUrl: './add-book-form.component.html',
  styleUrls: ['./add-book-form.component.css']
})
export class AddBookFormComponent implements OnInit {
  bookForm: FormGroup = new FormGroup({});
  allAuthors: AuthorType[] = [];
  allGenres: GenreType[] = [];
  genresChips: GenreType[] = [];
  authorsChips: AuthorType[] = [];
  separatorKeysCodes: number[] = [ENTER, COMMA];

  filteredAuthors: Observable<AuthorType[]> = new Observable();
  filteredGenres: Observable<GenreType[]> = new Observable();

  loading: boolean = false; // Flag variable
  file!: File; // Variable to store file
  uploadedImage: string | null = null;

  constructor(private formBuilder: FormBuilder, private authorsService: AuthorsService,
    private genresService: GenresService, private filesService: FileOperationsService,
    private booksService: BooksService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.bookForm = this.formBuilder.group({
      title: [null, [Validators.required]],
      description: [null, [Validators.required]],
      image: [null, [Validators.required]],
      authors: [null, [Validators.required]],
      genres: [null, [Validators.required]],
    });

    this.authorsService.getAllAuthors().subscribe(x => {
      this.allAuthors = x;
      this.setFilteredAuthors();
    });

    this.genresService.getAllGenres().subscribe(x => {
      this.allGenres = x;
      this.setFilteredGenres();
    });
  }

  setFilteredGenres(){
    this.filteredGenres = this.bookForm.controls['genres'].valueChanges.pipe(
      startWith(''),
      map(value => this.filterGenres(value || '')),
    );
  }

  setFilteredAuthors(){
    this.filteredAuthors = this.bookForm.controls['authors'].valueChanges.pipe(
      startWith(''),
      map(value => this.filterAuthors(value || '')),
    );
  }

  private filterAuthors(value: string): AuthorType[] {
    const filterValue = value.toLowerCase();
    return this.allAuthors.filter(option => option.name.toLowerCase().includes(filterValue));
  }

  private filterGenres(value: string): GenreType[] {
    console.log(value);
    const filterValue = value.toLowerCase();
    return this.allGenres.filter(option => option.name.toLowerCase().includes(filterValue));
  }

  onFileChange(event: any): void {
    this.file = event.target.files[0];

    const reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = () => {
      this.uploadedImage = reader.result as string;
    }
  }

  onUpload() {
    this.loading = !this.loading;
    this.filesService.uploadPhoto(this.file).subscribe(
      x => {
        this.bookForm.get('image')?.setValue(x.body);
        this.snackBar.open("Image uploaded!", "Ok", {
          duration: 2000,
        });
      }
    );
  }

  openInput() {
    document.getElementById("file-upload")?.click();
  }

  getOptionName(option: AuthorType | GenreType) {
    if (option)
      return option.name;
    else
      return ""
  }

  removeGenre(genre: GenreType): void {
    const index = this.genresChips.indexOf(genre);

    if (index >= 0) {
      this.genresChips.splice(index, 1);
    }
  }

  removeAuthor(author: AuthorType): void {
    const index = this.authorsChips.indexOf(author);

    if (index >= 0) {
      this.authorsChips.splice(index, 1);
    }
  }

  selectedGenre(event: MatAutocompleteSelectedEvent): void {
    if (!this.genresChips.includes(event.option.value)) {
     this.genresChips.push(event.option.value);
      event.option.deselect();
      this.bookForm.controls['genres'].reset();
      this.bookForm.controls['genres'].markAsPristine();
      this.bookForm.controls['genres'].markAsUntouched();
      this.setFilteredGenres();
    }
  }

  selectedAuthor(event: MatAutocompleteSelectedEvent): void {
    if (!this.authorsChips.includes(event.option.value)) {
      this.authorsChips.push(event.option.value)
      event.option.deselect();
      this.bookForm.controls['authors'].reset();
      this.bookForm.controls['authors'].markAsPristine();
      this.bookForm.controls['authors'].markAsUntouched();
      this.setFilteredAuthors();
    }
  }

  onSubmit(form: FormGroup) {
    this.bookForm.get('genres')?.setValue(this.genresChips.map(genre => genre.id));
    this.bookForm.get('authors')?.setValue(this.authorsChips.map(author => author.id));

    if (this.bookForm.valid) {
      var book: BookPostType = {
        title: this.bookForm.get('title')?.value, description: this.bookForm.get('description')?.value,
        image: this.bookForm.get('image')?.value, authorsId: this.bookForm.get('authors')?.value, genresId: this.bookForm.get('genres')?.value
      };
      this.booksService.postBook(book).subscribe();

      this.bookForm.reset();
      this.genresChips = [];
      this.authorsChips = [];
      this.uploadedImage = null;

      this.snackBar.open("Book added!", "Ok", {
        duration: 2000,
      });
    }
  }

}