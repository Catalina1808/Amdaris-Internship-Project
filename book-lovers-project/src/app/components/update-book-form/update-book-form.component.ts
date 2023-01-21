import { ENTER, COMMA } from '@angular/cdk/keycodes';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { AuthorType } from 'src/app/models/author.model';
import { BookPostType, BookType } from 'src/app/models/book.model';
import { GenreType } from 'src/app/models/genre.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { BooksService } from 'src/app/services/books.service';
import { FileOperationsService } from 'src/app/services/file-operations.service';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-update-book-form',
  templateUrl: './update-book-form.component.html',
  styleUrls: ['./update-book-form.component.css']
})
export class UpdateBookFormComponent implements OnInit {
  bookForm: FormGroup = new FormGroup({});
  allAuthors: AuthorType[] = [];
  allGenres: GenreType[] = [];
  genresChips: GenreType[] = [];
  authorsChips: AuthorType[] = [];
  separatorKeysCodes: number[] = [ENTER, COMMA];
  
  oldBook: BookType = {id:0, title:"", image:"", description:"", authors:[], genres:[]}

  loading: boolean = false; // Flag variable
  file!: File; // Variable to store file
  uploadedImage: string | null = null;

  constructor(private formBuilder: FormBuilder, private authorsService: AuthorsService,
    private genresService: GenresService, private filesService: FileOperationsService, 
    private booksService: BooksService, private snackBar: MatSnackBar, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    const bookId = this.activatedRoute.snapshot.paramMap.get("id");
    if (bookId)
      this.booksService.getBookById(+bookId).subscribe(x => { 
        this.oldBook = x;
        this.setForm(x); 
        this.genresChips = this.oldBook.genres;
        this.authorsChips = this.oldBook.authors;
      });
    this.setForm(this.oldBook)

    this.authorsService.getAllAuthors().subscribe(x => this.allAuthors = x);
    this.genresService.getAllGenres().subscribe(x => this.allGenres = x);
  }

  setForm(x: BookType) {
    this.bookForm = this.formBuilder.group({
      title: [x.title, [Validators.required]],
      description: [x.description, [Validators.required]],
      image: [x.image, [Validators.required]],
      authors: [x.authors, [Validators.required]],
      genres: [x.authors, [Validators.required]],
    });
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
    if (!this.genresChips.some(item => item.id === event.option.value.id)) {
      this.genresChips.push(event.option.value)
    }
  }

  selectedAuthor(event: MatAutocompleteSelectedEvent): void {
    if (!this.authorsChips.some(item => item.id === event.option.value.id)) {
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
      if(this.oldBook.id)
        this.booksService.putBook(book, this.oldBook.id).subscribe(x =>  
          this.snackBar.open("Book updated!", "Ok", {
          duration: 2000,
        }));
    }
  }
}