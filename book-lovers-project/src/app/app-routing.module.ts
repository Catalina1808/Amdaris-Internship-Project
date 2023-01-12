import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAuthorFormComponent } from './components/add-author-form/add-author-form.component';
import { AddBookFormComponent } from './components/add-book-form/add-book-form.component';
import { AllBooksPageComponent } from './components/all-books-page/all-books-page.component';
import { BookPageComponent } from './components/book-page/book-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { MyBooksPageComponent } from './components/my-books-page/my-books-page.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'my-books', component: MyBooksPageComponent },
  { path: 'all-books', component: AllBooksPageComponent},
  { path: 'login', component: LoginFormComponent},
  { path: 'register', component: RegisterFormComponent},
  { path: 'add-book', component: AddBookFormComponent},
  { path: 'add-author', component: AddAuthorFormComponent},
  { path: 'book/:id', component: BookPageComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
