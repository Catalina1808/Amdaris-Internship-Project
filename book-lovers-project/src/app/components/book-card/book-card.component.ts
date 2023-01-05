import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})
export class BookCardComponent {
  @Input() 
  title:string = "";
  @Input() 
  author:string = "";
  @Input() 
  image: string = ""

  @Output()
  sendDataEvent: EventEmitter<string> = new EventEmitter<string>();

   onButtonClick():void {
    this.sendDataEvent.emit("Button was clicked from " + this.title + " book.");
    }
}
