import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-add-shelf',
  templateUrl: './dialog-add-shelf.component.html',
  styleUrls: ['./dialog-add-shelf.component.css']
})
export class DialogAddShelfComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogAddShelfComponent>,
    @Inject(MAT_DIALOG_DATA) public name: string,
  ) {}
}
