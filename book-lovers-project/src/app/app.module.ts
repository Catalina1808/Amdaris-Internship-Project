import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookCardComponent } from './components/book-card/book-card.component';
import { HeartPipe } from './pipes/HeartPipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';  
import { MatInputModule } from '@angular/material/input';
import { HomePageComponent } from './components/home-page/home-page.component';
import { MyBooksPageComponent } from './components/my-books-page/my-books-page.component';


@NgModule({
  declarations: [
    AppComponent,
    BookCardComponent,
    HeartPipe,
    NavbarComponent,
    HomePageComponent,
    MyBooksPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
