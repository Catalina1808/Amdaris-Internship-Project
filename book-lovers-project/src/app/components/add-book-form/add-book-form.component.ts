import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-book-form',
  templateUrl: './add-book-form.component.html',
  styleUrls: ['./add-book-form.component.css']
})
export class AddBookFormComponent implements OnInit{
  bookForm: FormGroup = new FormGroup({});

constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.bookForm = this.formBuilder.group({
      title: [null, [Validators.required]],
      description: [null, [Validators.required]],
      authors: [null, [Validators.required]],
      genres: [null, [Validators.required]],
    });
  }

  onSubmit(form: FormGroup) {
    console.log(form);
  }
}