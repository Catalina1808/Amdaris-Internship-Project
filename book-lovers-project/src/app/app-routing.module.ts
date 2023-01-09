import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllBooksPageComponent } from './components/all-books-page/all-books-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { MyBooksPageComponent } from './components/my-books-page/my-books-page.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'my-books', component: MyBooksPageComponent },
  { path: 'all-books', component: AllBooksPageComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
