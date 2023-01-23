import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserType } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-all-users-page',
  templateUrl: './all-users-page.component.html',
  styleUrls: ['./all-users-page.component.css']
})
export class AllUsersPageComponent implements OnInit {
  users: UserType[] = [];
  displayedColumns: string[] = ['imagePath', 'userName', 'firstName', 'lastName', 'email', 'admin'];
  pageNumber: number = 1;
  pageSize: number = 3;
  totalPages: number = 0;
  disablePrevButton = true;
  disableNextButton = false;
  usersRoles: { userId: string, roles: string[] }[] = [];
  currentUserId: string = "";

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {   
    this.getInfoFromToken();
    this.getPage(this.pageNumber, this.pageSize);
  }

  getInfoFromToken(): void {
    const token = localStorage.getItem('token');
    if (token) {
      let jwtData = token.split('.')[1]
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.parse(decodedJwtJsonData)

      this.currentUserId = decodedJwtData.UserId;
    }
  }

  getUsersRoles(): void {
    this.usersRoles = [];
    this.users.forEach(user => {
      this.usersService.getUserRoles(user.id).subscribe(x =>
          this.usersRoles.push({ userId: user.id, roles: x }));
    });
  }

  isAdmin(user: UserType): boolean {
    const userRole = this.usersRoles.find(x => x.userId == user.id);
    if (userRole?.roles.includes('Admin'))
      return true;
    return false;
  }

  addAdminRole(user: UserType) {
    this.usersService.assignRole(user.id, "Admin").subscribe(x => this.getUsersRoles());
  }

  deleteAdminRole(user: UserType) {
    this.usersService.deleteRole(user.id, "Admin").subscribe(x => this.getUsersRoles());
  }

  onPrevClick() {
    this.getPage(this.pageNumber - 1, this.pageSize);
  }

  onNextClick() {
    this.getPage(this.pageNumber + 1, this.pageSize);
  }

  getPage(pageNumber: number, pageSize: number) {
    this.usersService.getAllUsers(pageNumber, pageSize).subscribe(x => {
      this.users = x.data.filter(user => user.id != this.currentUserId);
      this.totalPages = x.totalPages;
      this.pageNumber = x.pageNumber;
      this.verifyPagingButtons();
      this.getUsersRoles();
    });
  }

  verifyPagingButtons() {
    if (this.pageNumber === 1)
      this.disablePrevButton = true;
    else
      this.disablePrevButton = false;

    if (this.pageNumber === this.totalPages)
      this.disableNextButton = true;
    else
      this.disableNextButton = false;
  }
}
