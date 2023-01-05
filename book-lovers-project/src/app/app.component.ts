import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { BookCardComponent } from './components/book-card/book-card.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'book-lovers-project';

  books: Book[] = [
    {author:"Colleen Hoover", title:"Ugly love", image:"https://aestasbookblog.com/wp-content/uploads/2014/05/UglyLove-ColleenHoover.png"},
    {author:"Colleen Hoover", title:"Verity", image:"https://www.colleenhoover.com/wp-content/uploads/2018/09/Verity.jpg"},
    {author:"Colleen Hoover", title:"Heart Bones", image:"https://www.colleenhoover.com/wp-content/uploads/2020/06/51ufkkgyKfL-2.jpg"},
    {author:"Colleen Hoover", title:"maybe Someday", image:"https://m.media-amazon.com/images/I/71ZLa1mXoPL.jpg"},
  ]

  eventFromBook(event: any){
    console.log(event);
  }

  @ViewChild("bookCard")
  bookCard: BookCardComponent = new BookCardComponent;

  ngAfterViewInit(): void {
    console.log(this.bookCard);
  }

}

type Book = {
  title: string;
  author: string;
  image: string;
}
