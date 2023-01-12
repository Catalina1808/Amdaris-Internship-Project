import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserType } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit{
  registerForm: FormGroup = new FormGroup({});

constructor(private formBuilder: FormBuilder, private userService: UsersService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      password: [null, [Validators.required, Validators.minLength(6), this.containsDigitsAndLetters]],
    });
  }

  onSubmit(form: FormGroup) {
    console.log(form);
    var userFirstName: string = this.registerForm.get('firstName')?.value;
    var userLastName: string = this.registerForm.get('lastName')?.value;
    var userEmail: string = this.registerForm.get('email')?.value;
    var userPassword: string = this.registerForm.get('password')?.value;
    if (this.registerForm.valid) {
     var user: UserType = { id: 0, imagePath: "", firstName: userFirstName, lastName:userLastName, email:userEmail, password:userPassword};
      this.userService.postUser(user).subscribe();

      this.registerForm.get('firstName')?.setValue(null);
      this.registerForm.get('lastName')?.setValue(null);
      this.registerForm.get('email')?.setValue(null);
      this.registerForm.get('password')?.setValue(null);
      alert("User added!");
    }
  }

  containsDigitsAndLetters(control: FormControl): {[s: string]: boolean} | null {
    if(control.value != null && control.value.match("^(?=.*[a-zA-Z])(?=.*[0-9])")) {
      return null
    }

    return {"containsDigitsAndLetters": true}
  }

}