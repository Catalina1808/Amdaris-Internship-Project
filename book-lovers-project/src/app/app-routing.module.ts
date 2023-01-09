import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { MyBooksPageComponent } from './components/my-books-page/my-books-page.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'my-books', component: MyBooksPageComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
