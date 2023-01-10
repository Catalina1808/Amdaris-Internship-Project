import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit{
  registerForm: FormGroup = new FormGroup({});

constructor(private formBuilder: FormBuilder) { }

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
  }


  // get firstName() {
  //   return this.signUpForm.get('firstName');
  // }

  // get email() {
  //   return this.signUpForm.get('email');
  // }

  setFormlValues() {
    this.registerForm.patchValue({
      firstName: 'Gramada',
      lastName: 'Catalina',
      email: "ioana.gramada@amdaris.com",
      password: "123456"
    })
  }

  containsDigitsAndLetters(control: FormControl): {[s: string]: boolean} | null {
    if(control.value != null && control.value.match("^(?=.*[a-zA-Z])(?=.*[0-9])")) {
      return null
    }

    return {"containsDigitsAndLetters": true}
  }

}