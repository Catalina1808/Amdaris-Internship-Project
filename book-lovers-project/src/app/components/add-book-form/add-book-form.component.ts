import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import { Observable } from 'rxjs';
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

    this.authorsService.getAllAuthors().subscribe(x => this.allAuthors = x);
    this.genresService.getAllGenres().subscribe(x => this.allGenres = x);
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

  addGenre(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    const genre = this.allGenres.find((genre) => { return genre.name == value });
    // Add our fruit
    if (genre) {
      this.genresChips.push(genre);
    }
    // Clear the input value
    event.chipInput!.clear();
  }

  addAuthor(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    const author = this.allAuthors.find((author) => { return author.name == value });
    // Add our fruit
    if (author) {
      this.authorsChips.push(author);
    }
    // Clear the input value
    event.chipInput!.clear();
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
      this.genresChips.push(event.option.value)
    }
  }

  selectedAuthor(event: MatAutocompleteSelectedEvent): void {
    if (!this.authorsChips.includes(event.option.value)) {
      this.authorsChips.push(event.option.value)
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