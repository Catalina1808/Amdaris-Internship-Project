import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GenreType } from 'src/app/models/genre.model';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-add-genre-form',
  templateUrl: './add-genre-form.component.html',
  styleUrls: ['./add-genre-form.component.css']
})
export class AddGenreFormComponent {

  genreForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private genresService: GenresService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {

    this.genreForm = this.formBuilder.group({
      name: [null, [Validators.required]]
    });
  }

  onSubmit(form: FormGroup) {

    if (this.genreForm.valid) {
     const genre: GenreType = { id: 0, name: this.genreForm.get('name')?.value, books: []};
      
      this.genresService.postGenre(genre).subscribe(x => {
        this.genreForm.get('name')?.setValue(null);
        this.snackBar.open("Genre added!", "Ok", {
          duration: 2000,
        });
      },
      error => {
        console.log(error);
        this.snackBar.open(error.error , "Ok", {
          duration: 2000,
        });
      }
      );
    }
  }
}
