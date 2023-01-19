import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GenreType } from 'src/app/models/genre.model';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-add-genre-form',
  templateUrl: './add-genre-form.component.html',
  styleUrls: ['./add-genre-form.component.css']
})
export class AddGenreFormComponent {

  genreForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private genresService: GenresService) { }

  ngOnInit(): void {

    this.genreForm = this.formBuilder.group({
      name: [null, [Validators.required]]
    });
  }

  onSubmit(form: FormGroup) {

    if (this.genreForm.valid) {
     const genre: GenreType = { id: 0, name: this.genreForm.get('name')?.value, books: []};
      
      this.genresService.postGenre(genre).subscribe();
      this.genreForm.get('name')?.setValue(null);
      alert("Genre added!");
    }
  }
}