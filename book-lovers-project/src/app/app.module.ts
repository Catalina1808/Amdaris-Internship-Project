import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookCardComponent } from './components/book-card/book-card.component';
import { HeartPipe } from './pipes/HeartPipe';

@NgModule({
  declarations: [
    AppComponent,
    BookCardComponent,
    HeartPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
