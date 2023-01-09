import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MessagesService } from 'src/app/services/messages.service';

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

  constructor(private messageService: MessagesService){}

   onButtonClick():void {
    this.messageService.sayMessage("Button was clicked from " + this.title + " book.");
    this.sendDataEvent.emit("Button was clicked from " + this.title + " book.");
    }
}
