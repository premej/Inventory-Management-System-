import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewInventoryComponent } from './review-inventory.component';

describe('ReviewInventoryComponent', () => {
  let component: ReviewInventoryComponent;
  let fixture: ComponentFixture<ReviewInventoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReviewInventoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReviewInventoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
