import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthorType } from 'src/app/models/author.model';
import { AuthorsService } from 'src/app/services/authors.service';

@Component({
  selector: 'app-add-author-form',
  templateUrl: './add-author-form.component.html',
  styleUrls: ['./add-author-form.component.css']
})
export class AddAuthorFormComponent implements OnInit {

  authorForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private authorService: AuthorsService) { }

  ngOnInit(): void {

    this.authorForm = this.formBuilder.group({
      name: [null, [Validators.required]],
      description: [null, [Validators.required]]
    });
  }

  onSubmit(form: FormGroup) {
    console.log(form);
    var authorName: string = this.authorForm.get('name')?.value;
    var authorDescription: string = this.authorForm.get('description')?.value;
    if (authorName != null && authorDescription != null) {
     var author: AuthorType = { id: 0, name: authorName, description: authorDescription };
      this.authorService.postAuthor(author).subscribe();
      this.authorForm.get('name')?.setValue(null);
      this.authorForm.get('description')?.setValue(null);
      alert("Author added!");
    }
  }
}