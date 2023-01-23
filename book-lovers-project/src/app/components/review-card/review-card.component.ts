import { Component, Input, OnInit } from '@angular/core';
import { UserType } from 'src/app/models/user.model';

@Component({
  selector: 'app-review-card',
  templateUrl: './review-card.component.html',
  styleUrls: ['./review-card.component.css']
})
export class ReviewCardComponent{
  @Input()
  comment: string = "";
  @Input()
  user: UserType =  {id: "", userName: "", firstName: "", lastName: "", email: "", password:"", imagePath:"", authors:[]};

  @Input()
  date: Date = new Date();

}
