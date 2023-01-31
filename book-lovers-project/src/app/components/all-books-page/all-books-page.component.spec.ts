import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllBooksPageComponent } from './all-books-page.component';

describe('AllBooksPageComponent', () => {
  let component: AllBooksPageComponent;
  let fixture: ComponentFixture<AllBooksPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllBooksPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllBooksPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
