import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { AuthorType } from 'src/app/models/author.model';
import { AuthorsService } from 'src/app/services/authors.service';
import { FileOperationsService } from 'src/app/services/file-operations.service';

@Component({
  selector: 'app-update-author-form',
  templateUrl: './update-author-form.component.html',
  styleUrls: ['./update-author-form.component.css']
})
export class UpdateAuthorFormComponent implements OnInit {

  authorForm: FormGroup = new FormGroup({});

  loading: boolean = false; // Flag variable
  file!: File; // Variable to store file
  uploadedImage: string | null = null;

  oldAuthor: AuthorType = {id:0, name:"", image:"", description:"", books:[], followers:[]}

  constructor(private formBuilder: FormBuilder, private authorService: AuthorsService,
     private filesService: FileOperationsService, private snackBar: MatSnackBar, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    const authorId = this.activatedRoute.snapshot.paramMap.get("id");
    if (authorId)
      this.authorService.getAuthorById(+authorId).subscribe(x => { this.oldAuthor = x; this.setForm(x); });
    this.setForm(this.oldAuthor)
  }

  setForm(x: AuthorType) {
    this.authorForm = this.formBuilder.group({
      name: [x.name, [Validators.required]],
      description: [x.description, [Validators.required]],
      image: [x.image]
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
      this.authorForm.get('image')?.setValue(this.oldAuthor.image);
    }

    if (this.authorForm.valid) {
     const author: AuthorType = { id: this.oldAuthor.id, name: this.authorForm.get('name')?.value, books: [], followers:[],
      image: this.authorForm.get('image')?.value, description: this.authorForm.get('description')?.value};
      
      this.authorService.updateAuthor(author).subscribe( x => 
         this.snackBar.open("Author updated!", "Ok", {
        duration: 2000,
      }))
    }
  }
}
