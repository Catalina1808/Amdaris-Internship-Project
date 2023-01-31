import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogAddShelfComponent } from './dialog-add-shelf.component';

describe('DialogAddShelfComponent', () => {
  let component: DialogAddShelfComponent;
  let fixture: ComponentFixture<DialogAddShelfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogAddShelfComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogAddShelfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
