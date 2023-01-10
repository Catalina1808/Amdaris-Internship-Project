import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAuthorFormComponent } from './add-author-form.component';

describe('AddAuthorFormComponent', () => {
  let component: AddAuthorFormComponent;
  let fixture: ComponentFixture<AddAuthorFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAuthorFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddAuthorFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
