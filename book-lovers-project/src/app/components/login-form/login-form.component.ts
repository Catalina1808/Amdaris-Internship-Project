import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  constructor(private usersService: UsersService, private router: Router) { }

  onSubmit(loginForm: NgForm) {
    if (loginForm.valid) {
      this.usersService.loginUser(loginForm.value.userName, loginForm.value.password).subscribe(result => {
        localStorage.setItem('token', result.token);
        this.router.navigateByUrl('profile');
      });
    }
  }
}
