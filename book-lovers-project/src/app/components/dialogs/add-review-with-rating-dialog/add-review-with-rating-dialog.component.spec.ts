import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddReviewWithRatingDialogComponent } from './add-review-with-rating-dialog.component';

describe('AddReviewWithRatingDialogComponent', () => {
  let component: AddReviewWithRatingDialogComponent;
  let fixture: ComponentFixture<AddReviewWithRatingDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddReviewWithRatingDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddReviewWithRatingDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
