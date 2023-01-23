import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-review-with-rating-dialog',
  templateUrl: './add-review-with-rating-dialog.component.html',
  styleUrls: ['./add-review-with-rating-dialog.component.css']
})
export class AddReviewWithRatingDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AddReviewWithRatingDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { message: string, comment: string, rate: number }
  ) { }
}
