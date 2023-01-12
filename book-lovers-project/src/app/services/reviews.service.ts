import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReviewType } from '../models/review.model';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {
  constructor(private httpClient: HttpClient) {}

  postReview(review: ReviewType): Observable<ReviewType> {
    return this.httpClient.post<ReviewType>('api/Review', review);
  }
}
