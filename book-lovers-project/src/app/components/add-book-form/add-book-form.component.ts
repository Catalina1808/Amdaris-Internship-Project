import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthorType } from 'src/app/models/author.model';
import { GenreType } from 'src/app/models/genre.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-add-book-form',
  templateUrl: './add-book-form.component.html',
  styleUrls: ['./add-book-form.component.css']
})
export class AddBookFormComponent implements OnInit {
  bookForm: FormGroup = new FormGroup({});
  allAuthors: AuthorType[] = [];
  allGenres: GenreType[] = [];

  constructor(private formBuilder: FormBuilder, private authorsService: AuthorsService, private genresService: GenresService) { }

  ngOnInit(): void {

    this.bookForm = this.formBuilder.group({
      title: [null, [Validators.required]],
      description: [null, [Validators.required]],
      authors: [null, [Validators.required]],
      genres: [null, [Validators.required]],
    });

    this.authorsService.getAllAuthors().subscribe(x => this.allAuthors = x);
    this.genresService.getAllGenres().subscribe(x => this.allGenres = x);

  }

  getOptionName(option: AuthorType | GenreType) {
    if (option)
      return option.name;
    else
      return ""
  }
  onSubmit(form: FormGroup) {
    console.log(this.bookForm.get('authors')?.value);
  }
}