import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { UserType } from 'src/app/models/user.model';
import { FileOperationsService } from 'src/app/services/file-operations.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-update-user-form',
  templateUrl: './update-user-form.component.html',
  styleUrls: ['./update-user-form.component.css']
})
export class UpdateUserFormComponent {
  updateForm: FormGroup = new FormGroup({});
  uploadedImage: string | null = null;
  loading: boolean = false; // Flag variable
  file!: File; // Variable to store file
  oldUser: UserType = { id: "", userName: "", firstName: "", lastName: "", email: "", password: "", imagePath: "" };

  constructor(private router: Router, private formBuilder: FormBuilder, private activatedRoute: ActivatedRoute,
    private userService: UsersService, private filesService: FileOperationsService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    const userId = this.activatedRoute.snapshot.paramMap.get("id");
    if (userId)
      this.userService.getUserById(userId).subscribe(x => { this.oldUser = x; this.setForm(x); });
    this.setForm(this.oldUser)

  }

  setForm(x: UserType) {
    this.updateForm = this.formBuilder.group({
      firstName: [x.firstName, [Validators.required]],
      lastName: [x.lastName, [Validators.required]],
      userName: [x.userName, [Validators.required]],
      isAdmin: [this.isUserAdmin(), [Validators.required]],
      imagePath: [x.imagePath],
      email: [x.email, [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
    });
  }

  isUserAdmin(): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      let jwtData = token.split('.')[1];
      let decodedJwtJsonData = window.atob(jwtData);
      let decodedJwtData = JSON.parse(decodedJwtJsonData);

      if (decodedJwtData.role == "Admin")
        return true;
    }
    return false;
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
        this.updateForm.get('imagePath')?.setValue(x.body);
      }
    );
  }

  openInput() {
    document.getElementById("file-upload")?.click();
  }

  loginUser(user: UserType) {
    this.userService.loginUser(user.userName, user.password).subscribe(result => {
      localStorage.setItem('token', result.token);
      this.snackBar.open("User updated!", "Ok", {
        duration: 2000,
      });
      this.router.navigateByUrl('profile');
    });
  }

  onSubmit(form: FormGroup) {
    const isAdmin: Boolean = this.updateForm.get('isAdmin')?.value;

    if (!this.updateForm.get('imagePath')?.value) {
      this.updateForm.get('imagePath')?.setValue(this.oldUser.imagePath);
    }
    if (this.updateForm.valid) {
      const user: UserType = {
        id: this.oldUser.id, imagePath: this.updateForm.get('imagePath')?.value, userName: this.updateForm.get('userName')?.value,
        firstName: this.updateForm.get('firstName')?.value, lastName: this.updateForm.get('lastName')?.value,
        email: this.updateForm.get('email')?.value, password: this.oldUser.password
      };

      this.userService.updateUser(user).subscribe(result => {
        if (this.isUserAdmin() != isAdmin) {
          if (isAdmin)
            this.userService.assignRole(result.userId, "Admin").subscribe(x => this.loginUser(user));
          else
            this.userService.deleteRole(result.userId, "Admin").subscribe(x => this.loginUser(user));
        } else {
          this.loginUser(user)
        }

      });

    }
  }
}
