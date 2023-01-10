import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllBooksPageComponent } from './components/all-books-page/all-books-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { MyBooksPageComponent } from './components/my-books-page/my-books-page.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'my-books', component: MyBooksPageComponent },
  { path: 'all-books', component: AllBooksPageComponent},
  { path: 'login-form', component: LoginFormComponent},
  { path: 'register-form', component: RegisterFormComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
