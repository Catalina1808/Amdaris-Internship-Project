import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-review-dialog',
  templateUrl: './add-review-dialog.component.html',
  styleUrls: ['./add-review-dialog.component.css']
})
export class AddReviewDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AddReviewDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {message: string, comment: string}
  ) {}
}
