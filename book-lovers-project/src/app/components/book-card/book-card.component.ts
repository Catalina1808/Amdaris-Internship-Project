import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import { MessagesService } from 'src/app/services/messages.service';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})
export class BookCardComponent {
  @Input()
  title: string = "";
  @Input()
  author: string = "";
  @Input()
  image: string = "";
  @Input()
  id: number = 0;
  @Input()
  authorId: number = 0;
  @Input()
  currentRate: number = 0;

  constructor(private messageService: MessagesService, private config: NgbRatingConfig) {
    config.max = 5;
  }
}
