import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, NgForm, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  constructor(private usersService: UsersService, private router: Router, private snackBar: MatSnackBar) { }

  onSubmit(loginForm: NgForm) {
    if (loginForm.valid) {
      this.usersService.loginUser(loginForm.value.userName, loginForm.value.password).subscribe(
        result => {
        localStorage.setItem('token', result.token);
        let jwtData = result.token.split('.')[1]
        let decodedJwtJsonData = window.atob(jwtData)
        let decodedJwtData = JSON.parse(decodedJwtJsonData)
  
        const userId: string = decodedJwtData.UserId;
        this.router.navigate(['/user', userId]);
      },
      error => {
        this.snackBar.open("Incorrect username or password!", "Ok", {
          duration: 2000,
        });
      }
      );
    }
  }
}
