import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { UserType } from 'src/app/models/user.model';
import { FileOperationsService } from 'src/app/services/file-operations.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({});
  uploadedImage: string | null = null;
  loading: boolean = false; // Flag variable
  file!: File; // Variable to store file

  constructor(private router: Router, private formBuilder: FormBuilder, private snackBar: MatSnackBar,
    private userService: UsersService, private filesService: FileOperationsService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      userName: [null, [Validators.required]],
      imagePath: [null],
      email: [null, [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      password: [null, [Validators.required, Validators.minLength(6), this.containsDigitsAndLetters]],
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
        this.registerForm.get('imagePath')?.setValue(x.body);
        this.snackBar.open("Image uploaded!", "Ok", {
          duration: 2000,
        });
      }
    );
  }

  openInput() {
    document.getElementById("file-upload")?.click();
  }

  onSubmit() {
    if (!this.registerForm.get('imagePath')?.value) {
      this.registerForm.get('imagePath')?.setValue('https://booklovers.blob.core.windows.net/photos/NoProfileImage.png');
    }
    if (this.registerForm.valid) {
      const user: UserType = {
        id: "", imagePath: this.registerForm.get('imagePath')?.value, userName: this.registerForm.get('userName')?.value,
        firstName: this.registerForm.get('firstName')?.value, lastName: this.registerForm.get('lastName')?.value,
        email: this.registerForm.get('email')?.value, password: this.registerForm.get('password')?.value, authors:[]
      };

      this.userService.registerUser(user).subscribe();

      this.registerForm.reset();
      this.uploadedImage = null;
      this.snackBar.open("User added!", "Ok", {
        duration: 2000,
      });
      this.router.navigateByUrl('login');
    }
  }

  containsDigitsAndLetters(control: FormControl): { [s: string]: boolean } | null {
    if (control.value != null && control.value.match("^(?=.*[a-zA-Z])(?=.*[0-9])")) {
      return null
    }
    return { "containsDigitsAndLetters": true }
  }

}