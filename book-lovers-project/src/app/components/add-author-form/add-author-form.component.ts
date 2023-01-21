import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthorType } from 'src/app/models/author.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { FileOperationsService } from 'src/app/services/file-operations.service';

@Component({
  selector: 'app-add-author-form',
  templateUrl: './add-author-form.component.html',
  styleUrls: ['./add-author-form.component.css']
})
export class AddAuthorFormComponent implements OnInit {

  authorForm: FormGroup = new FormGroup({});

  loading: boolean = false; // Flag variable
  file!: File; // Variable to store file
  uploadedImage: string | null = null;

  constructor(private formBuilder: FormBuilder, private authorService: AuthorsService,
     private filesService: FileOperationsService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {

    this.authorForm = this.formBuilder.group({
      name: [null, [Validators.required]],
      description: [null, [Validators.required]],
      image: [null]
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
        this.authorForm.get('image')?.setValue(x.body); 
        this.snackBar.open("Image uploaded!", "Ok", {
          duration: 2000,
        });
      }
    );
  }

  openInput() {
    document.getElementById("file-upload")?.click();
  }

  onSubmit(form: FormGroup) {
    if(!this.authorForm.get('image')?.value){
      this.authorForm.get('image')?.setValue('https://booklovers.blob.core.windows.net/photos/NoProfileImage.png');
    }

    if (this.authorForm.valid) {
     const author: AuthorType = { id: 0, name: this.authorForm.get('name')?.value, books: [], followers:[],
      image: this.authorForm.get('image')?.value, description: this.authorForm.get('description')?.value};
      
      this.authorService.postAuthor(author).subscribe();
      this.authorForm.get('name')?.setValue(null);
      this.authorForm.get('description')?.setValue(null);
      this.uploadedImage = null;
      this.snackBar.open("Author added!", "Ok", {
        duration: 2000,
      });
    }
  }
}