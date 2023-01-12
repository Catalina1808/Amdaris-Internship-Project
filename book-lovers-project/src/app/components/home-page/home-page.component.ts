import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { BookType } from 'src/app/models/book.model';
import { BookCardComponent } from '../book-card/book-card.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements AfterViewInit{
  books: BookType[] = [
    {id:1, reviews:[], authors:[{id: 1, name:"Colleen Hoover", description:""}], description:"", title:"Ugly love", image:"https://aestasbookblog.com/wp-content/uploads/2014/05/UglyLove-ColleenHoover.png"},
    {id:2, reviews:[], authors:[{id: 1, name:"Colleen Hoover", description:""}], description:"", title:"Verity", image:"https://www.colleenhoover.com/wp-content/uploads/2018/09/Verity.jpg"},
    {id:3, reviews:[], authors:[{id: 1, name:"Colleen Hoover", description:""}], description:"", title:"Heart Bones", image:"https://www.colleenhoover.com/wp-content/uploads/2020/06/51ufkkgyKfL-2.jpg"},
    {id:4, reviews:[], authors:[{id: 1, name:"Colleen Hoover", description:""}], description:"", title:"maybe Someday", image:"https://m.media-amazon.com/images/I/71ZLa1mXoPL.jpg"},
  ]

  eventFromBook(event: any){
    console.log(event);
  }


  @ViewChild("bookCard")
  bookCard: BookCardComponent | undefined;

  ngAfterViewInit(): void {
    console.log(this.bookCard);
  }
}
