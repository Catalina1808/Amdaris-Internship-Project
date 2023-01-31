import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAuthorFormComponent } from './components/add-author-form/add-author-form.component';
import { AddBookFormComponent } from './components/add-book-form/add-book-form.component';
import { AddGenreFormComponent } from './components/genre-operations-form/add-genre-form.component';
import { AllBooksPageComponent } from './components/all-books-page/all-books-page.component';
import { AllUsersPageComponent } from './components/all-users-page/all-users-page.component';
import { AuthorPageComponent } from './components/author-page/author-page.component';
import { BookPageComponent } from './components/book-page/book-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { MyBooksPageComponent } from './components/my-books-page/my-books-page.component';
import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { UpdateAuthorFormComponent } from './components/update-author-form/update-author-form.component';
import { UpdateBookFormComponent } from './components/update-book-form/update-book-form.component';
import { UpdateUserFormComponent } from './components/update-user-form/update-user-form.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'my-books', component: MyBooksPageComponent },
  { path: 'all-books', component: AllBooksPageComponent},
  { path: 'login', component: LoginFormComponent},
  { path: 'register', component: RegisterFormComponent},
  { path: 'add-book', component: AddBookFormComponent},
  { path: 'add-author', component: AddAuthorFormComponent},
  { path: 'book/:id', component: BookPageComponent},
  { path: 'add-genre', component: AddGenreFormComponent},
  { path: 'author/:id', component: AuthorPageComponent},
  { path: 'user/:id', component: ProfilePageComponent},
  { path: 'all-users', component: AllUsersPageComponent},
  { path: 'update-profile/:id', component: UpdateUserFormComponent},
  { path: 'update-book/:id', component: UpdateBookFormComponent},
  { path: 'update-author/:id', component: UpdateAuthorFormComponent},
  { path: '', redirectTo: 'all-books', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
