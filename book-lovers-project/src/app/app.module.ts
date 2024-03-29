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
import { AllBooksPageComponent } from './components/all-books-page/all-books-page.component';

import { HttpClientModule } from '@angular/common/http';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AddBookFormComponent } from './components/add-book-form/add-book-form.component';
import { AddAuthorFormComponent } from './components/add-author-form/add-author-form.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatDialogModule} from '@angular/material/dialog';
import { DialogAddShelfComponent } from './components/dialogs/add-shelf-dialog/dialog-add-shelf.component';
import { DialogDeleteComponent } from './components/dialogs/delete-dialog/dialog-delete.component';
import { BookPageComponent } from './components/book-page/book-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatChipsModule} from '@angular/material/chips';
import { ReviewCardComponent } from './components/review-card/review-card.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatMenuModule} from '@angular/material/menu';
import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { UpdateUserFormComponent } from './components/update-user-form/update-user-form.component';
import { AddGenreFormComponent } from './components/genre-operations-form/add-genre-form.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { AuthorPageComponent } from './components/author-page/author-page.component';
import { UpdateBookFormComponent } from './components/update-book-form/update-book-form.component';
import { UpdateAuthorFormComponent } from './components/update-author-form/update-author-form.component';
import { AddReviewWithRatingDialogComponent } from './components/dialogs/add-review-with-rating-dialog/add-review-with-rating-dialog.component';
import { AllUsersPageComponent } from './components/all-users-page/all-users-page.component';
import {MatTableModule} from '@angular/material/table';


@NgModule({
  declarations: [
    AppComponent,
    BookCardComponent,
    HeartPipe,
    NavbarComponent,
    HomePageComponent,
    MyBooksPageComponent,
    AllBooksPageComponent,
    RegisterFormComponent,
    LoginFormComponent,
    AddBookFormComponent,
    AddAuthorFormComponent,
    DialogAddShelfComponent,
    DialogDeleteComponent,
    BookPageComponent,
    ReviewCardComponent,
    ProfilePageComponent,
    UpdateUserFormComponent,
    AddGenreFormComponent,
    AuthorPageComponent,
    UpdateBookFormComponent,
    UpdateAuthorFormComponent,
    AddReviewWithRatingDialogComponent,
    AllUsersPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MatSidenavModule,
    MatExpansionModule,
    MatDialogModule,
    NgbModule,
    MatAutocompleteModule,
    MatChipsModule,
    MatCheckboxModule,
    MatMenuModule,
    MatSnackBarModule,
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
