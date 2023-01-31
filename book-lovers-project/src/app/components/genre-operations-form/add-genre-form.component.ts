import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatSnackBar } from '@angular/material/snack-bar';
import { map, Observable, startWith } from 'rxjs';
import { GenreType } from 'src/app/models/genre.model';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-add-genre-form',
  templateUrl: './add-genre-form.component.html',
  styleUrls: ['./add-genre-form.component.css']
})
export class AddGenreFormComponent {
  allGenres: GenreType[] = [];

  genreAddForm: FormGroup = new FormGroup({});
  genreUpdateForm: FormGroup = new FormGroup({});
  genreDeleteForm: FormGroup = new FormGroup({});

  filteredUpdateGenres: Observable<GenreType[]> = new Observable();
  filteredDeleteGenres: Observable<GenreType[]> = new Observable();

  updateGenreId: number = 0;
  deleteGenreId: number = 0;

  constructor(private formBuilder: FormBuilder, private genresService: GenresService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.genreAddForm = this.formBuilder.group({
      name: [null, [Validators.required]]
    });
    this.genreUpdateForm = this.formBuilder.group({
      oldName:  [null, [Validators.required]],
      name: [null, [Validators.required]]
    });
    this.genreDeleteForm = this.formBuilder.group({
      name: [null, [Validators.required]]
    });

    this.refreshGenres();
  }

  refreshGenres(){
    this.genresService.getAllGenres().subscribe(x => {
      this.allGenres = x;
      this.filteredUpdateGenres = this.genreUpdateForm.controls['oldName'].valueChanges.pipe(
        startWith(''),
        map(value => this.filterGenres(value || '')),
      );
      this.filteredDeleteGenres = this.genreDeleteForm.controls['name'].valueChanges.pipe(
        startWith(''),
        map(value => this.filterGenres(value || '')),
      );
    });
  }

  private filterGenres(value: string): GenreType[] {
    const filterValue = value.toLowerCase();
    return this.allGenres.filter(option => option.name.toLowerCase().includes(filterValue));
  }

  selectedUpdateGenre(event: MatAutocompleteSelectedEvent): void {
    this.updateGenreId = event.option.value.id;
  }

  selectedDeleteGenre(event: MatAutocompleteSelectedEvent): void {
    this.updateGenreId = event.option.value.id;
  }

  getOptionName(option: GenreType) {
    if (option)
      return option.name;
    else
      return ""
  }

  onUpdateSubmit(form: FormGroup) {
    if(this.genreUpdateForm.valid){
    const genre: GenreType = { id: 0, name: this.genreUpdateForm.get('name')?.value, books: []}; 
    console.log(genre);  
     this.genresService.putGenre(genre, this.updateGenreId).subscribe(x => {
      this.refreshGenres();
      this.snackBar.open("Genre updated!", "Ok", {
        duration: 2000,
      });
     });
    }
  }
  onDeleteSubmit(form: FormGroup) {
    if(this.genreDeleteForm.valid)
     this.genresService.deleteGenre(this.updateGenreId).subscribe(x => {
      this.refreshGenres();
      this.snackBar.open("Genre deleted!", "Ok", {
        duration: 2000,
      });
     });
  }


  onAddSubmit(form: FormGroup) {
    if (this.genreAddForm.valid) {
     const genre: GenreType = { id: 0, name: this.genreAddForm.get('name')?.value, books: []};     
      this.genresService.postGenre(genre).subscribe(x => {
        this.genreAddForm.get('name')?.setValue(null);
        this.snackBar.open("Genre added!", "Ok", {
          duration: 2000,
        });
      },
      error => {
        console.log(error);
        this.snackBar.open(error.error , "Ok", {
          duration: 2000,
        });
      });
    }
  }
}
