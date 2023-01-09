import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { BookType } from 'src/app/book.model';
import { BookCardComponent } from '../book-card/book-card.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements AfterViewInit{
  books: BookType[] = [
    {id:1, author:"Colleen Hoover", title:"Ugly love", image:"https://aestasbookblog.com/wp-content/uploads/2014/05/UglyLove-ColleenHoover.png"},
    {id:2, author:"Colleen Hoover", title:"Verity", image:"https://www.colleenhoover.com/wp-content/uploads/2018/09/Verity.jpg"},
    {id:3, author:"Colleen Hoover", title:"Heart Bones", image:"https://www.colleenhoover.com/wp-content/uploads/2020/06/51ufkkgyKfL-2.jpg"},
    {id:4, author:"Colleen Hoover", title:"maybe Someday", image:"https://m.media-amazon.com/images/I/71ZLa1mXoPL.jpg"},
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
