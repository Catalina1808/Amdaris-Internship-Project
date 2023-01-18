import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, NgForm, Validators } from '@angular/forms';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  constructor(private usersService: UsersService) { }

  onSubmit(loginForm: NgForm) {
    if (loginForm.valid) {
      this.usersService.loginUser(loginForm.value.userName, loginForm.value.password).subscribe(result => {
        localStorage.setItem('token', result.token);
        const token = localStorage.getItem('token');
        if(token)
          this.getInfo(token);
      });
    }
  }

  getInfo(token: string ): void {
    let jwtData = token.split('.')[1]
    let decodedJwtJsonData = window.atob(jwtData)
    let decodedJwtData = JSON.parse(decodedJwtJsonData)

    let isAdmin = decodedJwtData.admin

    console.log('jwtData: ' + jwtData)
    console.log('decodedJwtJsonData: ' + decodedJwtJsonData)
    console.log('role ' + decodedJwtData.role)
  }
}
