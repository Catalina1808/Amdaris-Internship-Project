import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  userName: string = "";
  userImage: string = "";
  isAdmin: boolean = false;
  token: string | null= null;

  constructor(private router: Router){}

  getInfoFromToken(): boolean {
    this.token = localStorage.getItem('token');
    if (this.token) {
      let jwtData = this.token.split('.')[1]
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.parse(decodedJwtJsonData)

      if(decodedJwtData.role == "Admin"){
        this.isAdmin = true;
      } else {
        this.isAdmin = false;
      }

      this.userName = decodedJwtData.name;
      this.userImage = decodedJwtData.ImagePath;

      return true;
    }
    return false;
  }

  logOut(): void{
    localStorage.clear();
    this.router.navigateByUrl('all-books');
  }
}
